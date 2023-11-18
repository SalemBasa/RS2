﻿using Microsoft.AspNetCore.Mvc;
using TrashTrack.Core;
using TrashTrack.Application.Interfaces;
using TrashTrack.Infrastructure.Interfaces;

namespace TrashTrack.Api.Controllers
{
    public class ProductsController : BaseCrudController<ProductDto, ProductUpsertDto, ProductSearchObject, IProductsService>
    {
        private readonly IProductsService _service;
        public ProductsController(IProductsService service, ILogger<ProductsController> logger) : base(service, logger)
        {
        }
        
        [HttpGet("Recommended/{id}")]
        public List<Product> Recommend(int id)
        {
            return Service.Recommend(id);
        }
    }
}
