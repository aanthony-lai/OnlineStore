using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.DTO.ProductDTO;
using OnlineStore.API.Interfaces;

namespace OnlineStore.API.Controllers
{
    [Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductDTO>>> GetAllProducts([FromBody]int page = 0, [FromBody]int quantity = 0)
		{
			return await _productService.GetAllProducts(page, quantity);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDTO>> GetProductById(int id)
		{
			return await _productService.GetSingle(id);
		}

		[HttpPost]
		public async Task<ActionResult<ProductDTO>> AddProduct(CreateProductDTO Product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return await _productService.AddProduct(Product);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<ProductDTO>> UpdateProduct([FromRoute]int id, [FromBody]JsonPatchDocument productToUpdate)
		{
			return await _productService.UpdateProduct(id, productToUpdate);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ProductDTO>> DeleteProduct([FromRoute]int id)
		{
			return await _productService.DeleteProduct(id);
		}
	}
}
