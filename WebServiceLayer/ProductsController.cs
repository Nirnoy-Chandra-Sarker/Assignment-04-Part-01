using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        
        [HttpGet]
        public ActionResult<IEnumerable<DTOProductExt>> GetAllProducts()
        {

            var products = _dataService.GetProductByCategory(1);
            return Ok(products);
        }

        
        [HttpGet("{id}")]
        public ActionResult<DTOProductExt> GetProduct(int id)
        {
            var product = _dataService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<IEnumerable<DTOProductExt>> GetProductsByCategory(int categoryId)
        {
            var products = _dataService.GetProductByCategory(categoryId);
            if (products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }

    
        [HttpGet("name/{search}")]
        public ActionResult<IEnumerable<DTOProductCategory>> GetProductsByName(string search)
        {
            var products = _dataService.GetProductByName(search);
            if (products.Count == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }
    }
}
