using System.Collections.Generic;

namespace BookStore.Models
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
    }
}