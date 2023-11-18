using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Configurations
{
    public class GarbageConfiguration : BaseConfiguration<Garbage>
    {
        public override void Configure(EntityTypeBuilder<Garbage> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Address)
                   .IsRequired();

            builder.Property(e => e.GarbageType)
                   .IsRequired();

			builder.Property(e => e.Latitude)
				   .HasPrecision(18, 15);
			
			builder.Property(e => e.Longitude)
				   .HasPrecision(18, 15);
		}
    }
}
