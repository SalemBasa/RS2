namespace TrashTrack.Core
{
    public class FeedBackDto : BaseDto
    {
        public string? Comment { get; set; }
        public int Rating { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; } = null!;
    }
}
