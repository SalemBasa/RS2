using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IGarbagesService : IBaseService<int, GarbageDto, GarbageUpsertDto, GarbageSearchObject>
    {
        Task<int> GetPlasticGarbageCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetGlassGarbgeCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetMetalGarbageCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetOrganicGarbageCountAsync(CancellationToken cancellationToken = default);
    }
}


