using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class VehicleModelConfiguration : BaseConfiguration<VehicleModel>
    {
        public override void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Name)
                   .IsRequired();

            builder.Property(e => e.VehicleType)
                   .IsRequired();
        }
    }
}
