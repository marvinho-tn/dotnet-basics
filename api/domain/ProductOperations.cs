using api.common;

namespace api.domain
{
	public interface ICreateProductOperation
	{
		ValidationResultObject<Product> Execute(Product product);
	}

	public class CreateProductOperation(IProductRepository repository, ProductValidations productValidations)
		: ICreateProductOperation
	{
		public ValidationResultObject<Product> Execute(Product product)
		{
			var validations = productValidations.Validate(product);

			if(validations.Any())
			{
				return new ValidationResultObject<Product>
				{
					Errors = validations
				};
			}

			repository.Add(product);

			return new ValidationResultObject<Product>
			{
				Object = product
			};
		}
	}
}