namespace TrashTrack.Core
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public Role Role { get; set; }
        public DateTime? LastSignInAt { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public string? Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Balance { get; set; }

        public string? Photo { get; set; } 

        public ICollection<Notification>? Notifications { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; } = null!;
        public ICollection<Report> MyReports { get; set; } = null!;
        public ICollection<Reservation> Reservations { get; set; } = null!;
        public ICollection<Reward> Rewards { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        public ICollection<ScheduleDriver> ScheduleDrivers { get; set; } = null!;
    }
}
