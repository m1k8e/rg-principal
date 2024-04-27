namespace Rg_Data.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);

        IEnumerable<TEntity> Get();

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);
    }
}