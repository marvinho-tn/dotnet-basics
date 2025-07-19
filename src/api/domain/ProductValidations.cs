using api.common;

namespace api.domain;

public class ProductValidations
{
    public List<ValidationResult> Validate(Product product)
    {
        var validations = new List<ValidationResult>();

        if(string.IsNullOrEmpty(product.Name))
        {
            validations.Add(new ValidationResult(ValidationError.RequiredProductName));
        }
        if(string.IsNullOrEmpty(product.Description))
        {
            validations.Add(new ValidationResult(ValidationError.RequiredProductDescription));
        }
        if(product.Category is null || product.Category.Id <= 0)
        {
            validations.Add(new ValidationResult(ValidationError.RequiredProductCategory));
        }

        return validations;
    }
}