using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class FeedbackConfiguration : BaseConfiguration<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Rating)
                   .IsRequired();

            builder.HasOne(e => e.User)
                   .WithMany(e => e.Feedbacks)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired();
        }
    }
}
