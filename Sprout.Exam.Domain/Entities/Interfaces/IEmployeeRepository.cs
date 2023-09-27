namespace Sprout.Exam.Domain.Entities.Interfaces
{
    public interface IEmployeeRepository<TEntity>
        where TEntity: class
    {
        Task<IList<TEntity>> GetAll();

        Task<TEntity?> GetByIdAsync(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<bool> IsEmployeeUnique(Employee employee);
    }
}
