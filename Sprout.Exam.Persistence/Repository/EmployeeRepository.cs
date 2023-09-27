

namespace Sprout.Exam.Persistence.Repository
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        protected readonly ApplicationEmployeeContext DbContext;

        public EmployeeRepository(ApplicationEmployeeContext dbContext) 
        {
            DbContext = dbContext;
        }
        
        public void Add(Employee entity)
        {
            DbContext.Entry(entity).State = EntityState.Added;
            DbContext.Set<Employee>().Add(entity);
        }

        public void Delete(Employee entity)
        {
            DbContext.Entry(entity).State = EntityState.Deleted;
            DbContext.Set<Employee>().Remove(entity);
        }

        public async Task<IList<Employee>> GetAll()
        {
            return await DbContext.Set<Employee>().ToListAsync();
        }

        public Task<Employee?> GetByIdAsync(int id)
        {
            return DbContext.Set<Employee>().AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<bool> IsEmployeeUnique(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
             DbContext.Entry(entity).State = EntityState.Detached;
             DbContext.Set<Employee>().Update(entity);
        }
    }
}
