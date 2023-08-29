using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyStore.Models;

namespace MyStore.Data
{
	public class MyStrorDbContext : IdentityDbContext<IdentityUser>
    {
        public MyStrorDbContext(DbContextOptions<MyStrorDbContext> dbContextOptions) :base(dbContextOptions) 
        {
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//modelBuilder.Entity<Product>().HasKey(x => x.ProductId);
			modelBuilder.Entity<Product>()
				.HasOne<Category>(s => s.Category)
				.WithMany(x => x.Products)
				.HasForeignKey(g => g.CategoryId);

		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
