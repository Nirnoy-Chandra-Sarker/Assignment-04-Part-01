
using Microsoft.AspNetCore.Mvc;
using Assignment4;


namespace Assignment4.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }
        

        
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }

        
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var category = _dataService.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        
        [HttpPost]
        public ActionResult<Category> CreateCategory([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            var createdCategory = _dataService.CreateCategory(category.Name, category.Description);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] Category category)
        {
            if (category == null || category.Id != id)
            {
                return BadRequest();
            }

            var result = _dataService.UpdateCategory(id, category.Name, category.Description);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var result = _dataService.DeleteCategory(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}

