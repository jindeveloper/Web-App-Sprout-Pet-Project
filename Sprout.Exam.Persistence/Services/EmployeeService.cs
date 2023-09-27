namespace Sprout.Exam.Persistence.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeService(IUnitOfWork unitOfWork, IEmployeeRepository<Employee> employeeRepository)
        {
            this._unitOfWork = unitOfWork;
            this._employeeRepository = employeeRepository;
        }

        public async Task<int> CreateEmployee(Domain.Entities.Employee employee)
        {
           this._employeeRepository.Add(employee);
           var result = await this._unitOfWork.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<(bool, int)> DeleteEmployee(Domain.Entities.Employee employee)
        {
            this._employeeRepository.Delete(employee);

            await this._unitOfWork.SaveChangesAsync();

            return (true, employee.Id);

        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
           return await this._employeeRepository.GetByIdAsync(id);
        }

        public async Task<IList<Employee>> GetEmployees()
        {
            return await this._employeeRepository.GetAll();
        }

        public async Task UpdateEmployee(Employee item)
        {
            this._employeeRepository.Update(item);

            await this._unitOfWork.SaveChangesAsync();
        }
    } 
}
