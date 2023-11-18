using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Configurations;

public class ReservationConfiguration : BaseConfiguration<Reservation>
{
	public override void Configure(EntityTypeBuilder<Reservation> builder)
	{
		base.Configure(builder);
		
		builder.Property(e => e.Status)
			   .IsRequired();
		
		builder.Property(e => e.Latitude)
			   .HasPrecision(18, 15);
			
		builder.Property(e => e.Longitude)
			   .HasPrecision(18, 15);
		
		builder.HasOne(e => e.Service)
			   .WithMany(e => e.Reservations)
			   .HasForeignKey(e => e.ServiceId)
			   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			   .IsRequired();
		
		builder.HasOne(e => e.User)
			   .WithMany(e => e.Reservations)
			   .HasForeignKey(e => e.UserId)
			   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
			   .IsRequired();
	}
}
