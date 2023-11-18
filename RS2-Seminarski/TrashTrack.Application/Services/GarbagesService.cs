using AutoMapper;
using FluentValidation;
using TrashTrack.Application.Interfaces;
using TrashTrack.Core;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class GarbagesService : BaseService<Garbage, GarbageDto, GarbageUpsertDto, GarbageSearchObject, IGarbagesRepository>, IGarbagesService
    {
        public GarbagesService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<GarbageUpsertDto> validator) : base(mapper, unitOfWork, validator)
        {
        }

        public async Task<int> GetGlassGarbgeCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetGlassGarbgeCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetMetalGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetMetalGarbageCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetOrganicGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetOrganicGarbageCountAsync(cancellationToken);
            return count;
        }

        public async Task<int> GetPlasticGarbageCountAsync(CancellationToken cancellationToken = default)
        {
            var count = await CurrentRepository.GetPlasticGarbageCountAsync(cancellationToken);
            return count;
        }

        public override async Task<GarbageDto> AddAsync(GarbageUpsertDto dto, CancellationToken cancellationToken = default)
        {
            var garbage = Mapper.Map<Garbage>(dto);

            garbage.Occupancy = new Random().Next(1, 90);

            await CurrentRepository.AddAsync(garbage, cancellationToken);
            await UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapper.Map<GarbageDto>(garbage);
        }
    }
}
