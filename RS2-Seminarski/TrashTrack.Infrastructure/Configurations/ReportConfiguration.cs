using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
	public class ReportConfiguration : BaseConfiguration<Report>
	{
		public override void Configure(EntityTypeBuilder<Report> builder)
		{
			base.Configure(builder);

			builder.Property(e => e.Note)
				   .IsRequired();

			builder.Property(e => e.ReportState)
				   .IsRequired();

			builder.HasOne(e => e.ReporterUser)
				   .WithMany(e => e.MyReports)
				   .HasForeignKey(e => e.ReporterUserId)
				   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction)
				   .IsRequired();

			builder.HasOne(e => e.Garbage)
				   .WithMany(e => e.Reports)
				   .HasForeignKey(e => e.GarbageId)
				   .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
		}
	}
}
