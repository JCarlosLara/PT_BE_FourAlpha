using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSCoffeeShop.Models.Response;
using WSCoffeeShop.Models;
using WSCoffeeShop.Models.Request;

namespace WSCoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Category>> oResponse = new Response<List<Category>>();
            
            try 
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    var lstCategories = db.Categories.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = lstCategories;
                }
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }
                return Ok(oResponse);

        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Response<Category> oResponse = new Response<Category>(); 

            try 
            { 
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext()) 
                {
                    var lstCategories = db.Categories.Find(Id); 
                    oResponse.Success = 1; 
                    oResponse.Data = lstCategories; 
                }
            }
            catch (Exception ex) 
            {
                oResponse.Message = ex.Message; 
            }
            return Ok(oResponse);

        }
        [HttpPost]
        public IActionResult Add(CategoryRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    Category oCategory = new Category();
                    oCategory.Name = model.Name;
                    oCategory.Description = model.Description;
                    db.Categories.Add(oCategory);
                    db.SaveChanges(); 
                    oResponse.Success = 1; 
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpPut]
        public IActionResult Edit(CategoryRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    Category oCategory = db.Categories.Find(model.Id);
                    oCategory.Name = model.Name;
                    oCategory.Description = model.Description;
                    db.Categories.Add(oCategory);
                    db.Entry(oCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;                     
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            Response<object> oResponse = new Response<object>(); 

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    Category oCategory = db.Categories.Find(Id);
                    db.Remove(oCategory);
                    db.SaveChanges();
                    oResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }
    }
}
