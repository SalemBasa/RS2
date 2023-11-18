using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class NotificationConfiguration : BaseConfiguration<Notification>
    {
        public override void Configure(EntityTypeBuilder<Notification> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.DateSent)
                   .IsRequired();

            builder.Property(e => e.Message)
                   .IsRequired();

            builder.Property(e => e.Type)
                   .IsRequired();

            builder.Property(e => e.IsSeen)
                   .IsRequired();

            builder.HasOne(e => e.User)
                   .WithMany(e => e.Notifications)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired();
        }
    }
}
