using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportHub.API.Entities;

namespace SportHub.API.Data.Configurations
{
    public class PriceRuleConfiguration : IEntityTypeConfiguration<PriceRule>
    {
        public void Configure(EntityTypeBuilder<PriceRule> builder)
        {
            builder.Property(p => p.DayType).HasConversion<string>().HasMaxLength(10);
            builder.Property(p => p.PricePerHour).HasPrecision(18, 0);

            builder.HasOne(p => p.Court)
                   .WithMany(c => c.PriceRules)
                   .HasForeignKey(p => p.CourtId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
