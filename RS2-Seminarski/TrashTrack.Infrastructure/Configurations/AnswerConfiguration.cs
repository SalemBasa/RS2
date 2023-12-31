﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class AnswerConfiguration : BaseConfiguration<Answer>
    {
        public override void Configure(EntityTypeBuilder<Answer> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Content)
                   .IsRequired();

            builder.Property(e => e.IsTrue)
                   .IsRequired();

            builder.HasOne(e => e.Question)
                   .WithMany(e => e.Answers)
                   .HasForeignKey(e => e.QuestionId)
                   .IsRequired();
        }
    }
}
