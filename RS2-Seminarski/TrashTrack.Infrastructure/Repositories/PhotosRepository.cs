using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class PhotosRepository : BaseRepository<Photo, int, BaseSearchObject>, IPhotosRepository
    {
        public PhotosRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
