

namespace Sprout.Exam.Application.Employee
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(Sprout.Exam.Domain.Entities.Employee employee);

        Task<IList<Domain.Entities.Employee>> GetEmployees();

        Task<Domain.Entities.Employee> GetByIdAsync(int id);

        Task<(bool, int)> DeleteEmployee(Domain.Entities.Employee employee);

        Task UpdateEmployee(Domain.Entities.Employee item);
    }
}
