using OnlineStore.BlazorClient.Interfaces;
using OnlineStore.BlazorClient.Models;
using System.Net.Http.Json;

namespace OnlineStore.BlazorClient.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<ProductModel>> GetProductsFromCategoryAsync(int category)
        {
            var client = _httpClientFactory.CreateClient("OnlineStoreAPI");
            var response = await client.GetFromJsonAsync<List<ProductModel>>($"categories/{category}")
                ?? new List<ProductModel>();

            return response;
        }
    }
}
