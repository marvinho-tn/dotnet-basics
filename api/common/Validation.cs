using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.common
{
	public enum ValidationError
	{
		[Description("O nome do produto é obrigatório.")]
		RequiredProductName = 422001,

		[Description("A descrição do produto é obrigatória.")]
		RequiredProductDescription = 422002,

		[Description("A categoria do produto é obrigatória.")]
		RequiredProductCategory = 422003,
	}

	public class ValidationResult
	{
		public ValidationResult(ValidationError error)
		{
			Description = error.GetDescription();
			Name = error.ToString();
			Code = (int)error;
		}
		
		public string Description { get; }
		public string Name { get; }
		public int Code { get; }
	}

	public class ValidationResultObject<T>
	{
		public List<ValidationResult> Errors { get; set; } = [];
		public T Object { get; set; }
	}

	public static class ValidationErrorsExtensions
	{
		public static string GetDescription(this ValidationError error)
		{
			return DescriptionAttribute.GetCustomAttribute(error.GetType(), typeof(DescriptionAttribute)).GetType()
				.GetDefaultValue().ToString() ?? string.Empty;
		}
	}
}