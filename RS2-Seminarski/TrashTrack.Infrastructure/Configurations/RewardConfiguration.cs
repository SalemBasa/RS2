using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Configurations
{
    public class RewardConfiguration : BaseConfiguration<Reward>
    {
        public override void Configure(EntityTypeBuilder<Reward> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.User)
                   .WithMany(e => e.Rewards)
                   .HasForeignKey(e => e.UserId)
                   .IsRequired(false);

            builder.HasOne(e => e.Quiz)
                   .WithMany(e => e.Rewards)
                   .HasForeignKey(e => e.QuizId)
                   .IsRequired(false);

            builder.Property(e => e.MoneyEarned)
                   .IsRequired();

            builder.Property(e => e.Score)
                   .IsRequired();
        }
    }
}
