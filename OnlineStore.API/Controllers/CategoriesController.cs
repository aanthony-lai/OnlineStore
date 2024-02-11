using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.DTO;
using OnlineStore.API.DTO.Enums;
using OnlineStore.API.Interfaces;

namespace OnlineStore.API.Controllers
{
	[Route("api/products")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet("/categories")]
		public async Task<ActionResult<List<string>>> GetAllCategories()
		{
			return await _categoryService.GetAllCategories();
		}

		[HttpGet("/category/{category}")]
		public async Task<ActionResult<List<ProductDTO>>> GetProductsInCategory([FromRoute] CategoryEnums category)
		{
			return await _categoryService.GetProductsInCategory(category);
		}
	}
}
