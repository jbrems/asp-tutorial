using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_tutorial.Models;
using asp_tutorial.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_tutorial.Controllers {
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly ILogger _logger;

        public ProductController(ILogger<ProductController> logger, ProductService productService) {
            _logger = logger;
            this.ProductService = productService;
        }

        public ProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> GetProducts() {
            _logger.LogInformation("Retrieving all products");
            return ProductService.GetProducts();
        }

        [Route("{ProductId}")]
        [HttpGet]
        public Product GetProduct([FromRoute] string ProductId)
        {
            _logger.LogInformation($"Retrieving product with id {ProductId}");
            return ProductService.GetProducts().First(product => product.Id == ProductId);
        }

        [Route("{ProductId}/ratings")]
        [HttpGet]
        public int[] GetRatings([FromRoute] string ProductId)
        {
            _logger.LogInformation($"Retrieving ratings for product with id {ProductId}");
            return ProductService.GetProducts().First(product => product.Id == ProductId).Ratings;
        }

        [Route("{ProductId}/ratings")]
        [HttpPost]
        public ActionResult AddRating ([FromRoute] string ProductId, [FromForm] int rating)
        {
            _logger.LogInformation($"Adding rating {rating} to product with id {ProductId}");
            ProductService.AddRating(ProductId, rating);
            return Ok();
        }
    }
}
