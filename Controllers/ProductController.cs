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
        public IEnumerable<Product> GetProducts () {
            return ProductService.GetProducts();
        }

        [Route("rate")]
        [HttpGet]
        public ActionResult AddRating ([FromQuery] string ProductId, [FromQuery] int Rating)
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
