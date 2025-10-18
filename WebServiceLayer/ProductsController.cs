using Microsoft.AspNetCore.Mvc;
using Assignment4;

namespace Assignment4.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet("category/{id}")]
        public ActionResult<IList<Product>> GetProductsByCategory(int id)
        {
            var products = _dataService.GetProductByCategory(id);
            if (products == null || products.Count == 0)
                return NotFound();
            return Ok(products);
        }

        // [HttpGet]
        // public ActionResult<IList<ProductSearchModel>> GetProductsByName([FromQuery] string name)
        // {
        //     var products = _dataService.GetProductByName(name);
        //     if (products == null || products.Count == 0)
        //         return NotFound();
        //     return Ok(products);
        // }
    }
}

