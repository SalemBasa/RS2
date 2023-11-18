using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces;

public interface IServiceService : IBaseService<int, ServiceDto, ServiceUpsertDto, ServicesSearchObject>
{
	
}
