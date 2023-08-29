using Microsoft.AspNetCore.Identity;

namespace MyStore.Models
{
    public class MyStoreUser : IdentityUser
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
