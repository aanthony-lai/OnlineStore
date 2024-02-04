using OnlineStore.API.DTO;

namespace OnlineStore.API.Helpers
{
	public static class Pagination
	{
		public static List<ProductDTO> ReturnPaginatedList(int pageNumber, int resultsPerPage, List<ProductDTO> allProducts)
		{
			if (pageNumber == 0 && resultsPerPage == 0)
				return allProducts;

			if (resultsPerPage < 0)
				return new List<ProductDTO>();
			
			if (pageNumber < 0)
				return new List<ProductDTO>();

			int skip = (pageNumber - 1) * resultsPerPage;

			if (skip >= allProducts.Count)
				return new List<ProductDTO>();

			return allProducts.Skip(skip).Take(resultsPerPage).ToList();
		}
	}
}
 