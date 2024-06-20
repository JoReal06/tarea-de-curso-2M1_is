namespace Empresa_API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAllAsync(T entity);
        Task<T> GetAsync(T entity);
    }
}
