using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using asp_tutorial.Models;
using asp_tutorial.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_tutorial.Controllers {
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase {
        public ProductController(ProductService productService) {
            this.ProductService = productService;
        }

        public ProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> GetProducts() {
            return ProductService.GetProducts();
        }

        [Route("{ProductId}")]
        [HttpGet]
        public Product GetProduct([FromRoute] string ProductId)
        {
            return ProductService.GetProducts().First(product => product.Id == ProductId);
        }

        [Route("{ProductId}/ratings")]
        [HttpGet]
        public int[] GetRatings([FromRoute] string ProductId)
        {
            return ProductService.GetProducts().First(product => product.Id == ProductId).Ratings;
        }

        [Route("{ProductId}/ratings")]
        [HttpPost]
        public ActionResult AddRating ([FromRoute] string ProductId, [FromForm] int rating)
        {
            ProductService.AddRating(ProductId, rating);
            return Ok();
        }
    }
}
