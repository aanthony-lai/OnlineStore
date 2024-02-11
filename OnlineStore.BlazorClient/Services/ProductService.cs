using OnlineStore.BlazorClient.Interfaces;
using OnlineStore.BlazorClient.Models;
using System.Net.Http.Json;

namespace OnlineStore.BlazorClient.Services
{
	public class ProductService : IProductService
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<List<ProductModel>> GetProductsAsync()
		{
			var client = _httpClientFactory.CreateClient("OnlineStoreAPI");
			var response = await client.GetFromJsonAsync<List<ProductModel>>("products")
				?? new List<ProductModel>();

			return response;
		}
	}
}
