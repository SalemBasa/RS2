using TrashTrack.Core;

namespace TrashTrack.Infrastructure.Interfaces
{
    public class UserSearchObject : BaseSearchObject
    {
        public string? Query { get; set; }
        public Role? Role { get; set; }
    }
}