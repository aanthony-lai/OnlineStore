using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.DTO;
using OnlineStore.API.Interfaces;

namespace OnlineStore.API.Controllers
{
	[Authorize]
    [Route("api/products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet("/{page}/{quantity}")]
		public async Task<ActionResult<List<ProductDTO>>> GetAllProducts([FromRoute]int page = 0, [FromRoute]int quantity = 0)
		{
			return Ok(await _productService.GetAllProducts(page, quantity));
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ProductDTO>> GetProductById(int id)
		{
			return Ok(await _productService.GetSingleProduct(id));
		}

		[HttpPost]
		public async Task<ActionResult<ProductDTO>> AddProduct(CreateProductDTO Product)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			return Ok(await _productService.AddProduct(Product));
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<ProductDTO>> UpdateProduct([FromRoute]int id, [FromBody]JsonPatchDocument productToUpdate)
		{
			return Ok(await _productService.UpdateProduct(id, productToUpdate));
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ProductDTO>> DeleteProduct([FromRoute]int id)
		{
			return Ok(await _productService.DeleteProduct(id));
		}
	}
}
