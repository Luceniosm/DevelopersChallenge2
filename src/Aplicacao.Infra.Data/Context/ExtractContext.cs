using Aplicacao.Domain.Models;
using Aplicacao.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Aplicacao.Infra.Data.Context
{
    public class ExtractContext : DbContext
    {
        public ExtractContext()
        { }

        public DbSet<DataBank> DataBanks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DataBankMap());
            modelBuilder.ApplyConfiguration(new TransactionMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{envName}.json")
                .Build();

            // define the database to use
            optionsBuilder                                
                .UseSqlServer(config.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging();
        }
    }
}
