using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Domain.Mapping
{
    public class ConversionMapping : IEntityTypeConfiguration<ConversionEntity>
    {
        public void Configure(EntityTypeBuilder<ConversionEntity> builder)
        {
            builder.ToTable("Conversion");
            builder.HasKey(e => e.ID);

            builder.Property(e => e.CurrencyBase).HasMaxLength(3).IsUnicode().IsRequired();
            builder.Property(e => e.CurrencyQuote).HasMaxLength(3).IsUnicode().IsRequired();
            builder.Property(e => e.Ratio).HasColumnType("decimal(18,8)");
            builder.Property(e => e.Rate).HasColumnType("decimal(18,8)");
            builder.Property(e => e.InvRate).HasColumnType("decimal(18,8)");
            builder.Property(e => e.CreationDate).HasColumnType("date");
            builder.Property(e => e.ValidUntil).HasColumnType("date");

            builder.HasOne(e => e.CurrencyHistory).WithOne(e => e.Conversion);
        }
    }
}
