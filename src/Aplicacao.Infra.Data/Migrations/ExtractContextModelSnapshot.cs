﻿// <auto-generated />
using System;
using Aplicacao.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplicacao.Infra.Data.Migrations
{
    [DbContext(typeof(ExtractContext))]
    partial class ExtractContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aplicacao.Domain.Models.DataBank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnName("Account")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("CodeBank")
                        .IsRequired()
                        .HasColumnName("CodeBank")
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.ToTable("DataBank","dbo");
                });

            modelBuilder.Entity("Aplicacao.Domain.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasColumnName("Account")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("DateTrasaction")
                        .HasColumnName("DateTrasaction")
                        .HasColumnType("dateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("IdDataBank")
                        .HasColumnName("IdDataBank")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeTransaction")
                        .IsRequired()
                        .HasColumnName("CodeBank")
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdDataBank");

                    b.ToTable("Transaction","dbo");
                });

            modelBuilder.Entity("Aplicacao.Domain.Models.Transaction", b =>
                {
                    b.HasOne("Aplicacao.Domain.Models.DataBank", "DataBank")
                        .WithMany("Transactions")
                        .HasForeignKey("IdDataBank")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
