using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Configurations;

public class ServiceConfiguration : BaseConfiguration<Service>
{
	public override void Configure(EntityTypeBuilder<Service> builder)
	{
		base.Configure(builder);

		builder.Property(e => e.Name)
			   .IsRequired();

		builder.Property(e => e.Description)
			   .IsRequired();
	}
}
