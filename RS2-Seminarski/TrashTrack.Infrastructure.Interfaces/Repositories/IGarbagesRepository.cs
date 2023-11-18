using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public interface IGarbagesRepository : IBaseRepository<Garbage, int, GarbageSearchObject>
    {
        Task<int> GetPlasticGarbageCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetGlassGarbgeCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetMetalGarbageCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetOrganicGarbageCountAsync(CancellationToken cancellationToken = default);
    }
}
