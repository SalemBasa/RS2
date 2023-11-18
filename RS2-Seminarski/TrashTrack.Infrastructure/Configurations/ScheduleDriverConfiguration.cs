using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class ScheduleDriverConfiguration : IEntityTypeConfiguration<ScheduleDriver>
    {
        public void Configure(EntityTypeBuilder<ScheduleDriver> builder)
        {
            //builder.HasKey(sd => new { sd.ScheduleId, sd.DriverId });

            //builder.HasOne(sd => sd.Schedule)
            //    .WithMany(s => s.ScheduleDrivers)
            //    .HasForeignKey(sd => sd.ScheduleId);

            //builder.HasOne(sd => sd.Driver)
            //    .WithMany()
            //    .HasForeignKey(sd => sd.DriverId);
        }
    }
}
