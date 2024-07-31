using Microsoft.EntityFrameworkCore;

namespace WebLibrarySystem.Utility
{
    public class ApplicationDContext : DbContext
    {
        // veri tabanı ile entities arasındaki kopru.
        public ApplicationDContext(DbContextOptions<ApplicationDContext> options) : base(options)
        {
        }
        // class oluşturduktan sonra buraya eklemeyi unutma.
        public DbSet<Models.KitapTuru> KitapTuru { get; set; }
        public DbSet<Models.Kitap> Kitaplar { get; set; }
        public DbSet<Models.Kiralama> Kiralamalar { get; set; }
    }
}
