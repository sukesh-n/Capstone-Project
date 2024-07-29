namespace HotelBookingApp.Interface.IRepository
{
    public interface IMasterRepository<K, T> where T : class
    {
        Task<T> AddAsync(T enitity);
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(K id);
    }
}
