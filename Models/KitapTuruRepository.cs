using WebLibrarySystem.Utility;

namespace WebLibrarySystem.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        private ApplicationDContext _uygulamaDbContext;
        // dependent injection yapılıyor.
        public KitapTuruRepository(ApplicationDContext applicationDContext) : base(applicationDContext)
        {
            _uygulamaDbContext = applicationDContext;
        }
        public void Guncelle(KitapTuru kitapTuru)
        {
            _uygulamaDbContext.Update(kitapTuru);              
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();        
        }
    }
}
