﻿namespace MyStore.Models
{
	public class Product
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public string ManufactureDate { get; set; }

		public int CategoryId { get; set; }
		public virtual Category Category { get; set; }
	}
}
