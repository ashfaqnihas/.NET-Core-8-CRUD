using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_Appliction.Data;
using Mobile_Appliction.Model;

namespace Mobile_Appliction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public CategoryController (ApplicationDbContext context) { 
            
            _dbcontext = context;
        }

        //get data

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _dbcontext.Category.ToList();
            return Ok(categories);
        }

        // ceate data

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create([FromBody]Category category) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
              _dbcontext.Category.Add(category);
            _dbcontext.SaveChanges();
            return Ok();
        }

        // get data with id

     
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("Details")]

        public IActionResult Details(int id)
        {
          var category =  _dbcontext.Category.FirstOrDefault(c=>c.Id==id);

            if (category == null)
            {
                return NotFound("Category Not Found");
            } 
            return Ok(category);
        }

        //Update data

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult Update([FromBody]Category category) 
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           _dbcontext.Category.Update(category);
            _dbcontext.SaveChanges();
            return NoContent();
        
        }

        //Delete

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Delete(int id) 
        {
         if(id == 0)
            {
                return BadRequest();
            }
         var category = _dbcontext.Category.FirstOrDefault(x =>x.Id==id);
            if (category == null)
            {
                return NotFound();
            }

            _dbcontext.Category.Remove(category);
            _dbcontext.SaveChanges();
            return Ok();
        }
        
    }
}
