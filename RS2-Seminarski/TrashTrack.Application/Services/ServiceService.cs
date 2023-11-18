using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application;

public class ServiceService : BaseService<Service, ServiceDto, ServiceUpsertDto, ServicesSearchObject, IServiceRepository>, IServiceService
{
	public ServiceService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ServiceUpsertDto> validator) : base(mapper, unitOfWork, validator)
	{

	}
}
