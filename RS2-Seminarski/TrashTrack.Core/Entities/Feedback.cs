namespace TrashTrack.Core
{
    public class Feedback : BaseEntity
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
