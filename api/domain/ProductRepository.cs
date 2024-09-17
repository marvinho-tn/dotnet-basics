namespace api.domain
{
	public interface IProductRepository
	{
		void Add(Product product);
	}

	public class ProductRepository : IProductRepository
	{
		private static List<Product> _products = [];
		public void Add(Product product)
		{
			product.Id = _products.Count + 1;
			
			_products.Add(product);
		}
	}
}