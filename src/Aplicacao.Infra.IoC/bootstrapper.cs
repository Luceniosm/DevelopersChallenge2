using Aplicacao.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Aplicacao.Application.Interface;
using Aplicacao.Domain.Uow;
using Aplicacao.Infra.Data.Uow;
using Aplicacao.Infra.Data.Context;
using Aplicacao.Infra.Data.Repository;
using Aplicacao.Domain.Interface.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.IoC
{
    public class bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Aplication
            services.AddScoped<IUploadExtractsFilesService, UploadExtractsFilesService>();
            services.AddScoped<IExtractService, ExtractService>();
            #endregion

            #region Infra
            services.AddScoped<IDataBankRepository, DataBankRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            #endregion

            services.AddScoped<ExtractContext>();
        }
        public static void InitializeMigrations(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ExtractContext>();
            dbContext.Database.Migrate();
            dbContext.SaveChanges();
        }
    }
}

