using Aplicacao.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aplicacao.Infra.Data.Mappings
{
    public class DataBankMap : IEntityTypeConfiguration<DataBank>
    {
        public void Configure(EntityTypeBuilder<DataBank> builder)
        {
            builder.ToTable("DataBank", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(m => m.Id).HasColumnName("Id").HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(m => m.Account).HasColumnName("Account").HasColumnType("varchar(300)").IsRequired();
            builder.Property(m => m.CodeBank).HasColumnName("CodeBank").HasColumnType("varchar(300)").IsRequired();
        }
    }
}
