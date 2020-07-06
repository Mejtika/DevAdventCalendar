using System;
using DevAdventCalendarCompetition.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevAdventCalendarCompetition.Repository.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            builder.OwnsMany(t => t.HashedAnswers, b =>
#pragma warning restore CA1062 // Validate arguments of public methods
            {
                b.ToTable("TestAnswers");
            });

            builder
                .Property(t => t.SponsorLogoUrl)
                .HasConversion(v => v.ToString(), v => new Uri(v, UriKind.RelativeOrAbsolute));

            builder
                .Property(t => t.DiscountUrl)
                .HasConversion(v => v.ToString(), v => new Uri(v, UriKind.RelativeOrAbsolute));

            builder
                .Property(t => t.DiscountLogoUrl)
                .HasConversion(v => v.ToString(), v => new Uri(v, UriKind.RelativeOrAbsolute));
        }
    }
}
