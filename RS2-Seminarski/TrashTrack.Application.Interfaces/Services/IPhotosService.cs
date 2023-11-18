using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IPhotosService : IBaseService<int, PhotoDto, PhotoUpsertDto, BaseSearchObject>
    {

    }
}


