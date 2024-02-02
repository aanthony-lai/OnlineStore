using Microsoft.AspNetCore.JsonPatch;
using OnlineStore.API.DTO;

namespace OnlineStore.API.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductDTO>> GetAllProducts(int page, int quantity);
		Task<ProductDTO> GetSingleProduct(int id);
		Task<ProductDTO> AddProduct(CreateProductDTO product);
		Task<ProductDTO> UpdateProduct(int id, JsonPatchDocument productToUpdate);
		Task<ProductDTO> DeleteProduct(int id);
	}
}
