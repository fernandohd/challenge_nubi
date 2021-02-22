using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Domain.Mapping
{
    public class CurrencyHistoryMapping : IEntityTypeConfiguration<CurrencyHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<CurrencyHistoryEntity> builder)
        {
            builder.ToTable("CurrencyHistory");
            builder.HasKey(e => e.ID);

            builder.Property(e => e.CurrencyId).HasMaxLength(3).IsRequired();
            builder.Property(e => e.Symbol).HasMaxLength(3).IsUnicode();
            builder.Property(e => e.Description).HasMaxLength(50);
            builder.Property(e => e.DecimalPlaces).HasColumnType("int");

            builder.HasOne(e => e.Conversion).WithOne(e => e.CurrencyHistory).HasForeignKey<CurrencyHistoryEntity>(e => e.ToDolar);
        }
    }
}
