using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class VehicleConfiguration : BaseConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Color)
                   .IsRequired();

            builder.Property(e => e.LicensePlateNumber)
                   .IsRequired();

            builder.Property(e => e.ManufactureYear)
                   .IsRequired();

            builder.Property(e => e.Capacity)
                  .IsRequired();

            builder.HasOne(e => e.VehicleModel)
                   .WithMany(e => e.Vehicles)
                   .HasForeignKey(e => e.VehicleModelId)
                   .IsRequired();
        }
    }
}
