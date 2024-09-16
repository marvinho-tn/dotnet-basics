using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain
{
	public record Product
	{
		[Key]
		[Required]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public Category Category { get; set; }
	}

	public record Category
	{
		[Key]
		[Required]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		public Category Parent { get; set; }
	}

	public record ProductAttribute
	{
		[Key]
		[Required]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Value { get; set; }

		[Required]
		public Product Product { get; set; }
	}

	public enum AssetType
	{
		Image,
		Video
	}

	public record Asset
	{
		[Key]
		[Required]
		public long Id { get; set; }

		[Required]
		public string Uri { get; set; }

		[Required]
		public AssetType Type { get; set; }

		[Required]
		public Product Product { get; set; }
	}
}