using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Application
{
    public class ProductService : BaseService<Product, ProductDto, ProductUpsertDto, ProductSearchObject, IProductsRepository>, IProductsService
    {
        private readonly DatabaseContext _db;
        
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ProductUpsertDto> validator, DatabaseContext db) : base(mapper, unitOfWork, validator)
        {
            _db = db;
        }
        
        static object isLocked = new object();
        static MLContext mlContext = null;
        static ITransformer model = null;
        public List<Product> Recommend(int userId)
        {
            var all = _db.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).ToList();
            List<int> allproducts = new List<int>();
            foreach (var item in all)
            {
                foreach (var item2 in item.OrderDetails)
                {
                    allproducts.Add(item2.ProductId);
                }
            }
            if (allproducts.Distinct().Count() < 2)
                return new List<Product>();


            var orderProducts = _db.Orders.Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.UserId == userId).ToList();
            if (orderProducts.Count == 0)
                return new List<Product>();
            int id;
            List<int> products = new List<int>();
            foreach (var item in orderProducts)
            {
                foreach (var item2 in item.OrderDetails)
                {
                    products.Add(item2.ProductId);
                }
            }

            if (products.Distinct().Count() >= 2)
            {
                var list = products.Distinct();
                Random rand = new Random();
                int r = rand.Next(list.Count() - 1);
                id = products.ElementAt(r);
            }
            else
            {
                id = products.ElementAt(0);
            }

            lock (isLocked)
            {
                if (mlContext == null)
                {
                    mlContext = new MLContext();

                    var tmpData = _db.Orders.Include("OrderDetails").ToList();

                    var data = new List<ProductEntry>();

                    foreach (var x in tmpData)
                    {
                        if (x.OrderDetails.Count > 1)
                        {
                            var distinctItemId = x.OrderDetails.Select(y => y.ProductId).ToList();

                            distinctItemId.ForEach(y =>
                            {
                                var relatedItems = x.OrderDetails.Where(z => z.ProductId != y);

                                foreach (var z in relatedItems)
                                {
                                    data.Add(new ProductEntry()
                                    {
                                        ProductID = (uint)y,
                                        CoPurchaseProductID = (uint)z.ProductId,
                                    });
                                }
                            });
                        }
                    }


                    var traindata = mlContext.Data.LoadFromEnumerable(data);


                    MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                    options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                    options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                    options.LabelColumnName = "Label";
                    options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                    options.Alpha = 0.01;
                    options.Lambda = 0.025;
                    options.NumberOfIterations = 100;
                    options.C = 0.00001;


                    var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                    model = est.Fit(traindata);
                }

            }


            List<Product> allItems = _db.Products.ToList();

            var predictionResult = new List<Tuple<Product, float>>();

            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry, Copurchase_prediction>(model);
                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.Id
                });

                predictionResult.Add(new Tuple<Product, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).ToList();

            return Mapper.Map<List<Product>>(finalResult);
        }

        public class Copurchase_prediction
        {
            public float Score { get; set; }
        }

        public class ProductEntry
        {
            [KeyType(count: 10)]
            public uint ProductID { get; set; }

            [KeyType(count: 10)]
            public uint CoPurchaseProductID { get; set; }

            public float Label { get; set; }
        }
    }
}

