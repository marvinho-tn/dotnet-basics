using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace api.common
{
	public enum ValidationErrors
	{
		[Description("O nome do produto é obrigatório.")]
		RequiredProductName = 422001,

		[Description("A descrição do produto é obrigatória.")]
		RequiredProductDescription = 422002,

		[Description("A categoria do produto é obrigatória.")]
		RequiredProductCategory = 422003,
	}

	public static class ValidationErrorsExtensions
	{
		public static string GetDescription(this ValidationErrors error)
		{
			return string.Empty;
		}
	}
}