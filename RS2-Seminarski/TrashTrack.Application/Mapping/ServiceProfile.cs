using TrashTrack.Core;

namespace TrashTrack.Application.Mapping;

public class ServiceProfile : BaseProfile
{
	public ServiceProfile()
	{
		CreateMap<ServiceDto, Service>().ReverseMap();

		CreateMap<ServiceUpsertDto, Service>();
	}
}
