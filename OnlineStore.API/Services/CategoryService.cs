using OnlineStore.API.DTO;
using OnlineStore.API.DTO.Enums;
using OnlineStore.API.Helpers;
using OnlineStore.API.Interfaces;
using System.Text.Json;

namespace OnlineStore.API.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IHttpClientFactory _http;
		const string clientName = "FakeStoreAPI";
		public CategoryService(IHttpClientFactory httpClientFactory)
		{
			_http = httpClientFactory;
		}

		public async Task<List<string>> GetAllCategories()
		{
			var http = _http.CreateClient(clientName);
			var response = await http.GetFromJsonAsync<List<string>>("products/categories")
				?? new List<string>();

			return response;
		}
		public async Task<List<ProductDTO>> GetProductsInCategory(CategoryEnums category)
		{
			var http = _http.CreateClient(clientName);
			var option = GetEnumString.GetEnumStringValue(category);

			var response = await http.GetFromJsonAsync<List<ProductDTO>>($"products/category/{option}")
				?? new List<ProductDTO>();

			return response; 
		}
	}
}
