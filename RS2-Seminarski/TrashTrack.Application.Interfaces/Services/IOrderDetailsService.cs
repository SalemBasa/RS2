using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IOrderDetailsService : IBaseService<int, OrderDetailsDto, OrderDetailsUpsertDto, BaseSearchObject>
    {

    }
}




