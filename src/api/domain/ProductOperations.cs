using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain
{
	public interface ICreateProductOperation
	{
		ValidationResult Execute(Product product);
	}

	public interface IUpdateProductOperation
	{
		ValidationResult Execute(Product product);
	}

	public interface IDeleteProductOperation
	{
		ValidationResult Execute(long productId);
	}

	public interface ICreateCategoryOperation
	{
		ValidationResult Execute(Category category);
	}

	public interface IUpdateCategoryOperation
	{
		ValidationResult Execute(Category category);
	}

	public interface IDeleteCategoryOperation
	{
		ValidationResult Execute(long categoryId);
	}

	public class CreateProductOperation : ICreateProductOperation
	{
		private readonly IProductRepository _repository;

		public CreateProductOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(Product product)
		{
			var validation = new ValidationResult();

			if(string.IsNullOrEmpty(product.Name))
			{
				
			}
		}
	}

	public class UpdateProductOperation : IUpdateProductOperation
	{
		private readonly IProductRepository _repository;

		public UpdateProductOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(Product product)
		{
			
		}
	}

	public class DeleteProductOperation : IDeleteProductOperation
	{
		private readonly IProductRepository _repository;

		public DeleteProductOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(long productId)
		{
			
		}
	}

	public class CreateCategoryOperation : ICreateCategoryOperation
	{
		private readonly IProductRepository _repository;

		public CreateCategoryOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(Category category)
		{
			
		}
	}

	public class UpdateCategoryOperation : IUpdateCategoryOperation
	{
		private readonly IProductRepository _repository;

		public UpdateCategoryOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(Category category)
		{
			
		}
	}

	public class DeleteCategoryOperation : IDeleteCategoryOperation
	{
		private readonly IProductRepository _repository;

		public DeleteCategoryOperation(IProductRepository repository)
		{
			_repository = repository;
		}

		public ValidationResult Execute(long categoryId)
		{
			
		}
	}
}