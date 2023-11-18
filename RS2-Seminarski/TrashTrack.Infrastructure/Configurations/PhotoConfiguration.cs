using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public class PhotoConfiguration : BaseConfiguration<Photo>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Data)
                   .IsRequired();
        }
    }
}
