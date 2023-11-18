using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class GarbagesRepository : BaseRepository<Garbage, int, GarbageSearchObject>, IGarbagesRepository
    {
        public GarbagesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public async Task<int> GetGlassGarbgeCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(g => g.GarbageType == GarbageType.Glass).CountAsync(cancellationToken);
        }

        public async Task<int> GetMetalGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(g => g.GarbageType == GarbageType.Metal).CountAsync(cancellationToken);
        }

        public async Task<int> GetOrganicGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(g => g.GarbageType == GarbageType.Organic).CountAsync(cancellationToken);
        }

        public override async Task<PagedList<Garbage>> GetPagedAsync(GarbageSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(c=>searchObject.GarbageType == null || c.GarbageType == searchObject.GarbageType)
                              .Where(x => searchObject.Address == null || x.Address.ToLower().Contains(searchObject.Address.ToLower()))
                              .ToPagedListAsync(searchObject, cancellationToken);
        }

        public async Task<int> GetPlasticGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(g => g.GarbageType == GarbageType.Plastic).CountAsync(cancellationToken);
        }
    }
}