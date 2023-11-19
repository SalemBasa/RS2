using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application.Interfaces
{
    public interface IUsersService : IBaseService<int, UserDto, UserUpsertDto, UserSearchObject>
    {
        Task<UserSensitiveDto?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<OverviewCountDto<int>> GetCountByRoleAsync(Role role, CancellationToken cancellationToken = default);

        Task<int> GetUserCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetDriverCountAsync(CancellationToken cancellationToken = default);
        Task<int> GetAdministratorCountAsync(CancellationToken cancellationToken = default);
        
		Task<int> UpdateUserAsync(UserUpsertDto dto, CancellationToken cancellationToken = default);
    }
}



