using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain
{
	public interface IProductRepository
	{
		void Add(Product product);
		void Update(Product product);
		void Delete(Product product);
		void Add(Category category);
		void Update(Category category);
		void Delete(Category product);
	}
}