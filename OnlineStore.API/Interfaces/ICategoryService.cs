using OnlineStore.API.DTO;
using OnlineStore.API.DTO.Enums;

namespace OnlineStore.API.Interfaces
{
	public interface ICategoryService
	{
		Task<List<string>> GetAllCategories();
		Task<List<ProductDTO>> GetProductsInCategory(CategoryEnums category);
	}
}
