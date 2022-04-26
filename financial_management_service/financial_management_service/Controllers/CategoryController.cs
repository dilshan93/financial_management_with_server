using financial_management_service.Repositories;
using financial_management_service.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace financial_management_service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {


        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext applicationDbContext1)
        {
            _logger = logger;
            applicationDbContext = applicationDbContext1;
        }

        // GET: categoryList
        [HttpGet]
        public GenaralResponse Index()
        {
            IEnumerable<Category> categories = applicationDbContext.Categories.ToList();
            GenaralResponse response = new GenaralResponse();
            response.Sucess = true;
            response.Discription = "Found all categories !";
            response.ReturnResponse = categories;
            return response;
        }

        // POST: category/create
        [HttpPost("create")]
        public GenaralResponse Create([FromBody] Category formBody)
        {

            int existingCategoryCount = applicationDbContext.Categories.Where(cat => cat.Name == formBody.Name).Count();
            GenaralResponse response = new GenaralResponse();

            if (existingCategoryCount <= 0)
            {
                applicationDbContext.Categories.Add(formBody);
                applicationDbContext.SaveChanges();

                response.Sucess = true;
                response.Discription = "successfully Added New Category";
               
            }
            else
            {
                response.Sucess = false;
                response.Discription = "Category Already Added!";
            }
            
            return response;
        }

        // POST: category?id=x
        [HttpDelete]
        public GenaralResponse Delete(int id)
        {
            var category = applicationDbContext.Categories.FirstOrDefault(cat => cat.Id == id);
            GenaralResponse response = new GenaralResponse();
            if (category == null)
            {
                response.Sucess = false;
                response.Discription = "Category not found";
               
            }
            else
            {
                int numbTrans = applicationDbContext.Transactions.Where(c => c.Category.Id == id).Count();
                if (numbTrans > 0)
                {
                    response.Sucess = false;
                    response.Discription = " Please Delete Transactions Under This Category First !";
                }
                else
                {
                    applicationDbContext.Remove(category);
                    applicationDbContext.SaveChanges();

                response.Sucess = true;
                response.Discription = "Selected Category Deleted !";
                 }
            }
            return response;
        }

        // GET: category/liveness
        [HttpGet("liveness")]
        public GenaralResponse GetServerStatus()
        {
            GenaralResponse response = new GenaralResponse();
           
           
                response.Sucess = true;
                response.Discription = "Service is up";
                response.ReturnResponse = null;
           
            return response;
        }
    }

   
}
