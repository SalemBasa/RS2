using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class ScheduleGarbageConfiguration : IEntityTypeConfiguration<ScheduleGarbage>
    {
        public void Configure(EntityTypeBuilder<ScheduleGarbage> builder)
        {
            //builder.HasKey(sg => new { sg.ScheduleId, sg.GarbageId });

            //builder.HasOne(sg => sg.Schedule)
            //    .WithMany(s => s.ScheduleGarbages)
            //    .HasForeignKey(sg => sg.ScheduleId);

            //builder.HasOne(sg => sg.Garbage)
            //    .WithMany()
            //    .HasForeignKey(sg => sg.GarbageId);
        }
    }
}
