using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebLibrarySystem.Utility;

namespace WebLibrarySystem.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDContext _uygulamaDbContext;
        internal DbSet<T> dbSet; // dbSet ->uygulamaDbContext.KitapTuru demektense dbSet.KitapTuru demek daha mantıklı.
        public Repository(ApplicationDContext applicationDContext)
        {
            _uygulamaDbContext = applicationDContext;
            this.dbSet = _uygulamaDbContext.Set<T>(); 
            _uygulamaDbContext.Kitaplar.Include(k => k.KitapTuru).Include(k=>k.KitapTuruId); // Include ile foreign key ilişkili tabloları çekiyoruz.
        }
        public void Ekle(T entity)
        {
            dbSet.Add(entity);        
        }
        public T Get(Expression<Func<T, bool>> filtre, string? includeProps = null)
        {
           IQueryable<T> sorgu = dbSet;
           sorgu=sorgu.Where(filtre);
            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeProp);
                }
            }
            return sorgu.FirstOrDefault(); // sadece bir tane sorgu dondurmesi icin eklendi. 
        }
        public IEnumerable<T> GetAll(string? includeProps=null)
        {
            IQueryable<T> sorgu = dbSet;
            if(!string.IsNullOrEmpty(includeProps))
            {
               foreach (var includeProp in includeProps.Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries))
                {
                    sorgu = sorgu.Include(includeProp);
                }
            }  
            return sorgu.ToList();
        }
        public void Sil(T entity)
        {
            dbSet.Remove(entity); // tek bir entity silmek icin.
        }
        public void SilAralik(IEnumerable<T> entities)
        {
           dbSet.RemoveRange(entities); // birden fazla entity silmek icin.
        }
    }
}
