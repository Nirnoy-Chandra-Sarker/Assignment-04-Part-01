using Microsoft.AspNetCore.Mvc;
using Assignment4;

namespace Assignment4.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        
        [HttpGet]
        public ActionResult<IList<Category>> GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _dataService.GetCategory(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        
        // [HttpPost]
        // public ActionResult<Category> CreateCategory([FromBody] Category category)
        // {
        //     _dataService.CreateCategory(category);
        //     return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
        // }

        
        // [HttpPut("{id}")]
        // public ActionResult UpdateCategory(int id, [FromBody] Category category)
        // {
        //     if (id != category.Id)
        //         return BadRequest();

        //     bool success = _dataService.UpdateCategory(category);
        //     if (!success)
        //         return NotFound();
        //     return NoContent();
        // }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(int id)
        {
            bool success = _dataService.DeleteCategory(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}

