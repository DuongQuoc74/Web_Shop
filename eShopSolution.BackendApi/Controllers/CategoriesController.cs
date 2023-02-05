using eShpsolution.Application.Catalog.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryservice;
        public CategoriesController(ICategoryService categoryService) 
        {
            _categoryservice= categoryService;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetAll(string languageId)
        {
            var product = await _categoryservice.GetAll(languageId);
            return Ok(product);
        }

        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetById(string languageId, int id)
        {
           var category = await _categoryservice.GetById(id, languageId);
            return Ok(category);
        }
    }
}
