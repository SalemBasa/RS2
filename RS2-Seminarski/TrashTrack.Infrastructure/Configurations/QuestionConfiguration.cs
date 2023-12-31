﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class QuestionConfiguration : BaseConfiguration<Question>
    {
        public override void Configure(EntityTypeBuilder<Question> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Content)
                   .IsRequired();

            builder.Property(e => e.Points)
                   .IsRequired();

            builder.HasOne(e => e.Quiz)
                   .WithMany(e => e.Questions)
                   .HasForeignKey(e => e.QuizId)
                   .IsRequired();
        }
    }
}
