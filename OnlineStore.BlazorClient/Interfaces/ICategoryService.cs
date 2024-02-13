using OnlineStore.BlazorClient.Models;

namespace OnlineStore.BlazorClient.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ProductModel>> GetProductsFromCategoryAsync(int category);
    }
}
