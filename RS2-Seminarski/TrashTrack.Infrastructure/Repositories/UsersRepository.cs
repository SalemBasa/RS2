using Microsoft.EntityFrameworkCore;

using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class UsersRepository : BaseRepository<User, int, UserSearchObject>, IUsersRepository
    {
        public UsersRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public override Task<PagedList<User>> GetPagedAsync(UserSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet
                .Where(u => searchObject.Query == null || (u.FirstName.ToLower().Contains(searchObject.Query.ToLower()) ||
                                                          u.LastName.ToLower().Contains(searchObject.Query.ToLower()) ||
                                                          u.Email.ToLower().Contains(searchObject.Query.ToLower()) ||
                                                          u.PhoneNumber.ToLower().Contains(searchObject.Query.ToLower())))
                .Where(u=>(searchObject.Role == null || u.Role == searchObject.Role))
                .ToPagedListAsync(searchObject, cancellationToken);
        }

        public async Task<int> GetCountByRoleAsync(Role role, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(u => u.Role == role).CountAsync(cancellationToken);
        }

        public async Task<int> GetUserCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(u => u.Role == Role.User).CountAsync(cancellationToken);
        }

        public async Task<int> GetDriverCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(u => u.Role == Role.Driver).CountAsync(cancellationToken);
        }

        public async Task<int> GetAdministratorCountAsync(CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(u => u.Role == Role.Administrator).CountAsync(cancellationToken);
        }
    }
}
