using api.common;
using api.domain;

namespace api.application;

public class CreateProductAttributeModel
{
    public string Name { get; set; }
    public string Value { get; set; }
}

public class CreateProductModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long CategoryId { get; set; }
    public List<CreateProductAttributeModel> Attributes { get; set; }

    public Product ConvertToProduct()
    {
	    return new Product
	    {
			Name = Name,
			Description = Description,
			Category = new Category
			{
				Id = CategoryId
			},
			Attributes = Attributes.Select(attribute => new ProductAttribute
			{
				Name = attribute.Name,
				Value = attribute.Value
			}).ToList()
	    };
    }
}

public interface ICreateProductDecorator
{
	ValidationResultObject<Product> Execute(CreateProductModel input);
}

public class CreateProductDecorator(ICreateProductOperation operation) : ICreateProductDecorator
{
	public ValidationResultObject<Product> Execute(CreateProductModel input)
	{
		var product = input.ConvertToProduct();
		var result = operation.Execute(product);

		return result;
	}
}