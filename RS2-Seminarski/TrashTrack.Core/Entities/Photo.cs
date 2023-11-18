namespace TrashTrack.Core
{
    public class Photo : BaseEntity
    {
        public string Data { get; set; } = null!;
        
        public ICollection<User> Users { get; set; } = null!;
        public ICollection<Report> Reports { get; set; } = null!;
    }
}
