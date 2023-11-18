namespace TrashTrack.Core
{
    public class NotificationDto : BaseDto
    {
        public DateTime DateSent { get; set; }
        public string Message { get; set; } = null!;
        public NotificationType Type { get; set; }
        public bool IsSeen { get; set; }

        public int UserId { get; set; }
        public UserDto User { get; set; } = null!;
    }
}
