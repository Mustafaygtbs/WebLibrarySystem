using System.Collections;
using System.Linq.Expressions;

namespace WebLibrarySystem.Models
{
    public interface IRepository<T>where T:class
    {
        // T-> KitapTuru
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T,bool>>filtre, string? includeProps = null);
        void Ekle(T entity);
        void Sil(T entity);
        void SilAralik(IEnumerable<T> entities);
    }
}
