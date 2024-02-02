using Microsoft.AspNetCore.JsonPatch;
using OnlineStore.API.DTO;
using OnlineStore.API.Helpers;
using OnlineStore.API.Interfaces;

namespace OnlineStore.API.Services
{
    public class ProductService : IProductService
	{
		private readonly IHttpClientFactory _http;
		const string clientName = "FakeStoreAPI";
		public ProductService(IHttpClientFactory httpClientFactory)
		{
			_http = httpClientFactory;
		}

		public async Task<List<ProductDTO>> GetAllProducts(int pageNumber, int resultsPerPage)
		{
			var http = _http.CreateClient(clientName);
			var response = await http.GetFromJsonAsync<List<ProductDTO>>("products")
				?? new List<ProductDTO>();

			return Pagination.ReturnPaginatedList(pageNumber, resultsPerPage, response);
		}

		public async Task<ProductDTO> GetSingleProduct(int id)
		{
			var http = _http.CreateClient(clientName);
			var response = await http.GetFromJsonAsync<ProductDTO>($"products/{id}")
				?? throw new ArgumentOutOfRangeException($"Sorry product with id: {id} couldn't be found!");

			return response;
		}

		public async Task<ProductDTO> AddProduct(CreateProductDTO Product)
		{
			var http = _http.CreateClient(clientName);
			var product = new CreateProductDTO
			{
				title = Product.title,
				price = Product.price,
				category = Product.category,
				description = Product.description,
				image = Product.image
			};

			var response = await http.PostAsJsonAsync("products", product);

			if (!response.IsSuccessStatusCode)
			{
				throw new HttpRequestException($"Request to add a product failed with status code {response.StatusCode}. The reason is: {response.ReasonPhrase}");
			}

			var createdProduct = await response.Content.ReadFromJsonAsync<ProductDTO>()
				?? new ProductDTO();

			return createdProduct;
		}

		public async Task<ProductDTO> UpdateProduct(int id, JsonPatchDocument productToUpdate)
		{
			var http = _http.CreateClient(clientName);
			var product = await http.GetFromJsonAsync<ProductDTO>($"products/{id}");

			if (product != null)
			{
				productToUpdate.ApplyTo(product);
				return product;
			}
			else
			{
				throw new Exception("Product can't be found.");
			}
		}

		public async Task<ProductDTO> DeleteProduct(int id)
		{
			var http = _http.CreateClient(clientName);
			var response = await http.DeleteAsync($"products/{id}");
			
			if (!response.IsSuccessStatusCode)
			{
				throw new HttpRequestException($"Request to add a product failed with status code {response.StatusCode}. The reason is: {response.ReasonPhrase}");
			}

			return await response.Content.ReadFromJsonAsync<ProductDTO>()
				?? throw new Exception("Product with this id couldn't be found.");
		}

		public async Task<List<CategoryDTO>> GetAllCategories()
		{
			var http = _http.CreateClient(clientName);
			var response = await http.GetFromJsonAsync<List<CategoryDTO>>("products/categories")
				?? new List<CategoryDTO>();

			return response;
		}
	}
}
