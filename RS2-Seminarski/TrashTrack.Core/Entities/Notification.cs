namespace TrashTrack.Core
{
    public class Notification : BaseEntity
    {
        public DateTime DateSent { get; set; }
        public string Message { get; set; } = null!;
        public NotificationType Type { get; set; }
        public bool IsSeen { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
