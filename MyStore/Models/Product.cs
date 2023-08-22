namespace MyStore.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string ManufactureDate { get; set; }

		public int CategoryId { get; set; }
		public Category Category { get; set; }
	}

	public class AddViewModel
	{
        public string Name { get; set; }
        public int Price { get; set; }
        public string ManufactureDate { get; set; }
        public  IEnumerable<Category> categories { get; set; }
        public Category Category { get; set; }
    }
}
