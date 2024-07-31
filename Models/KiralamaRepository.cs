using WebLibrarySystem.Utility;

namespace WebLibrarySystem.Models
{
    public class KiralamaRpository : Repository<Kiralama>, IKiralamaRepository
    {
        private ApplicationDContext _uygulamaDbContext;
        // dependent injection yapılıyor.
        public KiralamaRpository(ApplicationDContext applicationDContext) : base(applicationDContext)
        {
            _uygulamaDbContext = applicationDContext;
        }
        public void Guncelle(Kiralama kiralama)
        {
            _uygulamaDbContext.Update(kiralama);              
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();        
        }
    }
}
