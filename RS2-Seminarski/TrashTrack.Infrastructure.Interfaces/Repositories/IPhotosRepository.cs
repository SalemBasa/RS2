using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IPhotosRepository : IBaseRepository<Photo, int, BaseSearchObject>
    {
    }
}

