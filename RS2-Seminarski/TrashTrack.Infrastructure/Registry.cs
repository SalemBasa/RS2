using Microsoft.Extensions.DependencyInjection;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public static class Registry
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<IPhotosRepository, PhotosRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IReportsRepository, ReportsRepository>();
            services.AddScoped<IFeedbacksRepository, FeedbacksRepository>();
            services.AddScoped<IGarbagesRepository, GarbagesRepository>();
            services.AddScoped<INotificationsRepository, NotificationsRepository>();
            services.AddScoped<IRewardsRepository, RewardsRepository> ();
            services.AddScoped<ISchedulesRepository, SchedulesRepository> ();
            services.AddScoped<IVehicleModelsRepository, VehicleModelsRepository> ();
            services.AddScoped<IVehiclesRepository, VehiclesRepository> ();
            services.AddScoped<IServiceRepository, ServiceRepository> ();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IQuizzesRepository, QuizzesRepository>();
            services.AddScoped<IScheduleDriversRepository, ScheduleDriversRepository>();
            services.AddScoped<IScheduleGarbagesRepository, ScheduleGarbagesRepository>();
            services.AddScoped<INotificationRabbitRepository, NotificationRabbitRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
