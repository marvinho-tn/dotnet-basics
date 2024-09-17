using Microsoft.AspNetCore.Mvc;

namespace api.application;

[ApiController]
[Route("/api/product")]
public class ProductController(ICreateProductDecorator decorator) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct(CreateProductModel input)
    {
        var result = decorator.Execute(input);

        if (result.Errors.Any())
        {
            return UnprocessableEntity(result);
        }
        
        return Created($"/api/products/{result.Object.Id}", result);
    }
}