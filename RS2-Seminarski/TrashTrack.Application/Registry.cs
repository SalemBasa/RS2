using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

using TrashTrack.Core;
using TrashTrack.Application.Interfaces;

namespace TrashTrack.Application
{
    public static class Registry
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<ICountriesService, CountriesService>();
            services.AddScoped<IFeedbacksService, FeedbacksService>();
            services.AddScoped<IGarbagesService, GarbagesService>();
            services.AddScoped<IPhotosService, PhotosService>();
            services.AddScoped<INotificationsService, NotificationsService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRewardsService, RewardsService>();
            services.AddScoped<ISchedulesService, SchedulesService>();
            services.AddScoped<IVehicleModelsService, VehicleModelsService>();
            services.AddScoped<IReportsService, ReportsService>();
            services.AddScoped<IVehiclesService, VehiclesService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IAnswersService, AnswersService>();
            services.AddScoped<IQuestionsService, QuestionsService>();
            services.AddScoped<IQuizzesService, QuizzesService>();
            services.AddScoped<IScheduleDriversService, ScheduleDriversService>();
            services.AddScoped<IScheduleGarbagesService, ScheduleGarbagesService>();
            services.AddScoped<INotificationRabbitService, NotificationRabbitService>();
            services.AddScoped<IProductsService, ProductService>();
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IOrdersService, OrdersService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CityUpsertDto>, CityValidator>();
            services.AddScoped<IValidator<CountryUpsertDto>, CountryValidator>();
            services.AddScoped<IValidator<FeedbackUpsertDto>, FeedbackValidator>();
            services.AddScoped<IValidator<GarbageUpsertDto>, GarbageValidator>();
            services.AddScoped<IValidator<PhotoUpsertDto>, PhotoValidator>();
            services.AddScoped<IValidator<NotificationUpsertDto>, NotificationValidator>();
            services.AddScoped<IValidator<UserUpsertDto>, UserValidator>();
            services.AddScoped<IValidator<RewardUpsertDto>, RewardValidator>();
            services.AddScoped<IValidator<ScheduleUpsertDto>, ScheduleValidator>();
            services.AddScoped<IValidator<VehicleModelUpsertDto>, VehicleModelValidator>();
            services.AddScoped<IValidator<ReportTypeUpsertDto>, ReportTypeValidator>();
            services.AddScoped<IValidator<ReportUpsertDto>, ReportValidator>();
            services.AddScoped<IValidator<VehicleUpsertDto>, VehicleValidator>();
            services.AddScoped<IValidator<UserChangePasswordDto>, UserPasswordValidator>();
            services.AddScoped<IValidator<ServiceUpsertDto>, ServiceValidator>();
            services.AddScoped<IValidator<ReservationUpsertDto>, ReservationValidator>();
            services.AddScoped<IValidator<AnswerUpsertDto>, AnswerValidator>();
            services.AddScoped<IValidator<QuestionUpsertDto>, QuestionValidator>();
            services.AddScoped<IValidator<QuizUpsertDto>, QuizValidator>();
            services.AddScoped<IValidator<ScheduleDriverUpsertDto>, ScheduleDriverValidator>();
            services.AddScoped<IValidator<ScheduleGarbageUpsertDto>, ScheduleGarbageValidator>();
            services.AddScoped<IValidator<ProductUpsertDto>, ProductValidator>();
            services.AddScoped<IValidator<OrderUpsertDto>, OrderValidator>();
            services.AddScoped<IValidator<OrderDetailsUpsertDto>, OrderDetailsValidator>();
            services.AddScoped<IValidator<NotificationRabbitUpsertDto>, NotificationRabbitValidator>();

        }
    }
}
