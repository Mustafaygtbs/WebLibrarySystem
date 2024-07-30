using WebLibrarySystem.Utility;

namespace WebLibrarySystem.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private ApplicationDContext _uygulamaDbContext;
        // dependent injection yapılıyor.
        public KitapRepository(ApplicationDContext applicationDContext) : base(applicationDContext)
        {
            _uygulamaDbContext = applicationDContext;
        }
        public void Guncelle(Kitap kitap)
        {
            _uygulamaDbContext.Update(kitap);              
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();        
        }
    }
}
