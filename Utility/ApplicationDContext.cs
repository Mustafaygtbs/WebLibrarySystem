using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebLibrarySystem.Models;


namespace WebLibrarySystem.Utility
{
    // veri tabanında EF tablosu oluşması için ilgili model sınıfının buraya eklenmesi lazım.
    public class ApplicationDContext : IdentityDbContext
    {
        // veri tabanı ile entities arasındaki kopru.
        public ApplicationDContext(DbContextOptions<ApplicationDContext> options) : base(options)
        {}

        public DbSet<Models.KitapTuru> KitapTuru { get; set; }
        public DbSet<Models.Kitap> Kitaplar { get; set; }
        public DbSet<Models.Kiralama> Kiralamalar { get; set; }
        public DbSet<Models.ApplicationUser> ApplicationUsers { get; set; }
    
        // class oluşturduktan sonra buraya eklemeyi unutma.
   }
}
