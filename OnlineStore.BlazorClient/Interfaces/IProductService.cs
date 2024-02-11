using OnlineStore.BlazorClient.Models;
using System.Dynamic;

namespace OnlineStore.BlazorClient.Interfaces
{
	public interface IProductService
	{
		Task<List<ProductModel>> GetProductsAsync();
	}
}
