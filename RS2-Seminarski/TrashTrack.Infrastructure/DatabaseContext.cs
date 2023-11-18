using Microsoft.EntityFrameworkCore;
using TrashTrack.Core;

namespace TrashTrack.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Photo> Photos { get; set; } = null!;
        public DbSet<Feedback> Feedbacks { get; set; } = null!;
        public DbSet<Garbage> Garbages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Notification> Notifications { get; set; } = null!;
        public DbSet<Reward> Rewards { get; set; } = null!;
        public DbSet<VehicleModel> VehicleModels { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Answer> Answers { get; set; } = null!;
        public DbSet<Question> Questions { get; set; } = null!;
        public DbSet<Quiz> Quizzes { get; set; } = null!;
        public DbSet<ScheduleDriver> ScheduleDrivers { get; set; } = null!;
        public DbSet<ScheduleGarbage> ScheduleGarbages { get; set; } = null!;
        public DbSet<NotificationRabbit> NotificationsRabbit { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetails> OrderDetails { get; set; } = null!;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
            ApplyConfigurations(modelBuilder);
        }
    }
}
