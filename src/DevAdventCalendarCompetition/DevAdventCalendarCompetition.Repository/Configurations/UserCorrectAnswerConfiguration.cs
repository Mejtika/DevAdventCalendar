using System;
using DevAdventCalendarCompetition.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevAdventCalendarCompetition.Repository.Configurations
{
    public class UserCorrectAnswerConfiguration : IEntityTypeConfiguration<UserTestCorrectAnswer>
    {
        public void Configure(EntityTypeBuilder<UserTestCorrectAnswer> builder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            builder.HasKey(ut => ut.Id);
#pragma warning restore CA1062 // Validate arguments of public methods

            builder.HasOne(ut => ut.Test)
                .WithMany(t => t.UserCorrectAnswers)
                .HasForeignKey(ut => ut.TestId);

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.CorrectAnswers)
                .HasForeignKey(ut => ut.UserId);
        }
    }
}