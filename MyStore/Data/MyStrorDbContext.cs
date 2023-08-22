using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.Data
{
	public class MyStrorDbContext : DbContext
	{
        public MyStrorDbContext(DbContextOptions<MyStrorDbContext> dbContextOptions) :base(dbContextOptions) 
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
			modelBuilder.Entity<Product>(entity =>
			{
				entity.HasOne<Category>()
				.WithMany(x => x.Products)
				.HasForeignKey(x => x.ProductId);
			});
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
