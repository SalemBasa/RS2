using Microsoft.EntityFrameworkCore.Storage;

using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;

        public readonly ICountriesRepository CountriesRepository;
        public readonly ICitiesRepository CitiesRepository;
        public readonly IPhotosRepository PhotosRepository;
        public readonly IUsersRepository UsersRepository;
        public readonly IVehicleModelsRepository VehicleModelsRepository;
        public readonly IReportsRepository ReportsRepository;
        public readonly IFeedbacksRepository FeedbacksRepository;
        public readonly IGarbagesRepository GarbagesRepository;
        public readonly INotificationsRepository NotificationsRepository;
        public readonly IRewardsRepository RewardsRepository;
        public readonly ISchedulesRepository SchedulesRepository;
        public readonly IVehiclesRepository VehiclesRepository;
        public readonly IServiceRepository ServiceRepository;
        public readonly IReservationRepository ReservationRepository;
        public readonly IAnswersRepository AnswersRepository;
        public readonly IQuestionsRepository QuestionsRepository;
        public readonly IQuizzesRepository QuizzesRepository;
        public readonly IScheduleDriversRepository ScheduleDriversRepository;
        public readonly IScheduleGarbagesRepository ScheduleGarbagesRepository;
        public readonly INotificationRabbitRepository NotificationRabbitRepository;
        public readonly IProductsRepository ProductsRepository;
        public readonly IOrdersRepository OrdersRepository;
        public readonly IOrderDetailsRepository OrderDetailsRepository;


        public UnitOfWork(
            DatabaseContext databaseContext,
            ICountriesRepository countriesRepository,
            ICitiesRepository citiesRepository,
            IPhotosRepository photosRepository,
            IUsersRepository usersRepository,
            IVehicleModelsRepository vehicleModelsRepository,
            IReportsRepository reportsRepository,
            IFeedbacksRepository feedbacksRepository,
            IGarbagesRepository garbagesRepository,
            INotificationsRepository notificationsRepository,
            IRewardsRepository rewardsRepository,
            ISchedulesRepository schedulesRepository,
            IVehiclesRepository vehiclesRepository,
            IServiceRepository serviceRepository,
            IReservationRepository reservationRepository,
            IAnswersRepository answersRepository,
            IQuestionsRepository questionsRepository,
            IQuizzesRepository quizzesRepository,
            IScheduleDriversRepository scheduleDriversRepository,
            IScheduleGarbagesRepository scheduleGarbagesRepository,
            INotificationRabbitRepository notificationRabbitRepository,
            IProductsRepository productsRepository,
            IOrdersRepository ordersRepository,
            IOrderDetailsRepository orderDetailsRepository)
        {
            _databaseContext = databaseContext;

            CountriesRepository = countriesRepository;
            CitiesRepository = citiesRepository;
            UsersRepository = usersRepository;
            VehicleModelsRepository = vehicleModelsRepository;
            ReportsRepository = reportsRepository;
            FeedbacksRepository = feedbacksRepository;
            GarbagesRepository = garbagesRepository;
            NotificationsRepository = notificationsRepository;
            RewardsRepository = rewardsRepository;
            SchedulesRepository = schedulesRepository;
            SchedulesRepository = schedulesRepository;
            VehiclesRepository = vehiclesRepository;
            ServiceRepository = serviceRepository;
            ReservationRepository = reservationRepository;
            PhotosRepository = photosRepository;
            AnswersRepository = answersRepository;
            QuestionsRepository = questionsRepository;
            QuizzesRepository = quizzesRepository;
            ScheduleDriversRepository = scheduleDriversRepository;
            ScheduleGarbagesRepository = scheduleGarbagesRepository;
            NotificationRabbitRepository = notificationRabbitRepository;
            ProductsRepository = productsRepository;
            OrdersRepository = ordersRepository;
            OrderDetailsRepository = orderDetailsRepository;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await _databaseContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _databaseContext.Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _databaseContext.Database.RollbackTransactionAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _databaseContext.SaveChangesAsync(cancellationToken);
        }
    }
}
