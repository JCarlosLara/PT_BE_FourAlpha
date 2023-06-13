using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSCoffeeShop.Models.Response;
using WSCoffeeShop.Models;
using WSCoffeeShop.Models.Request;
using Microsoft.EntityFrameworkCore;

namespace WSCoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response<List<Product>> oResponse = new Response<List<Product>>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    //var lstProducts = db.Products.ToList();  
                    var lstProducts = db.Products.Include(x => x.Category).ToList(); 
                    oResponse.Success = 1; 
                    oResponse.Data = lstProducts; 
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Response<Product> oResponse = new Response<Product>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                { 
                    var uniqueProduct = db.Products
                        .Where(p => p.Id == Id)
                        .Include(x => x.Category).FirstOrDefault();

                    oResponse.Success = 1; 
                    oResponse.Data = uniqueProduct;
                }
            }
            catch (Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            return Ok(oResponse);

        }

        [HttpPost]
        public IActionResult Add(ProductRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    Product oProduct = new Product();
                    oProduct.Name = model.Name; 
                    oProduct.Description = model.Description;
                    oProduct.Active = true; //model.Active; 
                    oProduct.Stock = model.Stock; 
                    oProduct.Price = model.Price;
                    oProduct.BrandId = 1; // model.BrandId; 
                    oProduct.CategoryId = 1;// model.CategoryId; 
                     
                    db.Products.Add(oProduct);
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
        public IActionResult Edit(ProductRequest model)
        {
            Response<object> oResponse = new Response<object>();

            try
            {
                using (CrudcoffeeshopContext db = new CrudcoffeeshopContext())
                {
                    Product oProduct = db.Products.Find(model.Id);                     
                    oProduct.Name = model.Name; 
                    oProduct.Description = model.Description; 
                    oProduct.Active = model.Active; 
                    oProduct.Stock = model.Stock; 
                    oProduct.Price = model.Price; 
                    oProduct.BrandId = model.BrandId; 
                    oProduct.CategoryId = model.CategoryId; 
                    db.Products.Add(oProduct); 
                    db.Entry(oProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
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
                    Product oProduct = db.Products.Find(Id);
                    db.Remove(oProduct);
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
