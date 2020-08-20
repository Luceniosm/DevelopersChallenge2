using Aplicacao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacao.Infra.Data.Mappings
{
    public class TransactionMap: IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.IdDataBank).HasColumnName("IdDataBank").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.Description).HasColumnName("Description").HasColumnType("varchar(300)").IsRequired();
            builder.Property(m => m.Amount).HasColumnName("Account").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(m => m.DateTrasaction).HasColumnName("DateTrasaction").HasColumnType("dateTime").IsRequired();
            builder.Property(m => m.TypeTransaction).HasColumnName("CodeBank").HasColumnType("varchar(300)").IsRequired();

            builder
                .HasOne(m => m.DataBank)
                .WithMany(m => m.Transactions)
                .HasForeignKey(m => m.IdDataBank)
                .IsRequired();
        }
    }
}
