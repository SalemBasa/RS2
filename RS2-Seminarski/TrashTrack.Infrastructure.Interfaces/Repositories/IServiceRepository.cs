using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces;

public interface IServiceRepository : IBaseRepository<Service, int, ServicesSearchObject>
{
	
}
