using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class QuizzesRepository : BaseRepository<Quiz, int, QuizzesSearchObject>, IQuizzesRepository
    {
        public QuizzesRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public override Task<PagedList<Quiz>> GetPagedAsync(QuizzesSearchObject searchObject, CancellationToken cancellationToken = default)
        {
            return DbSet.AsNoTracking()
                .Include(q => q.Rewards)
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .Where(q => searchObject.Title == null || q.Title.Contains(searchObject.Title))
                .ToPagedListAsync(searchObject, cancellationToken);
        }
    }
}
