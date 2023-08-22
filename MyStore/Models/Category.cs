using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
	public class Category
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }

		[ForeignKey("ProductId")]
		public int ProductId { get; set; }
		public virtual ICollection<Product> Products { get; set; }
	}
}
