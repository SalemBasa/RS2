using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure;

public class ServiceRepository : BaseRepository<Service, int, ServicesSearchObject>, IServiceRepository
{
	public ServiceRepository(DatabaseContext databaseContext) : base(databaseContext)
	{
		
	}

	public override async Task<PagedList<Service>> GetPagedAsync(ServicesSearchObject searchObject, CancellationToken cancellationToken = default)
	{
		return await DbSet.Where(x => searchObject.Name == null || x.Name.ToLower().Contains(searchObject.Name.ToLower()))
						  .ToPagedListAsync(searchObject, cancellationToken);
	}
}
