namespace Sprout.Exam.Business.Factory
{
    public static class EmployeeSalaryConstants
    {
        public static decimal EMPLOYEE_REGULAR_BASIC_SALARY = 20000.00m;
        public static decimal EMPLOYEE_CONTRACTUAL_SALARY = 500.00m;
    }

    public interface IEmployeeFactory
    {
        decimal Calculate(EmployeeCalculateInput employeeCalculate);
    }

    internal class RegularEmployee : IEmployeeFactory
    {
        public string CalculatedValue { get; }

        public decimal Calculate(EmployeeCalculateInput employeeCalculate)
        {
            var salary = (EmployeeSalaryConstants.EMPLOYEE_REGULAR_BASIC_SALARY - 
                    ((EmployeeSalaryConstants.EMPLOYEE_REGULAR_BASIC_SALARY /22) * employeeCalculate.AbsentDays)
                    - (EmployeeSalaryConstants.EMPLOYEE_REGULAR_BASIC_SALARY * 0.12m));

            return salary;
        }
    }

    internal class ContractualEmloyee : IEmployeeFactory
    {
        public decimal Calculate(EmployeeCalculateInput employeeCalculate)
        {
            var salary = (EmployeeSalaryConstants.EMPLOYEE_CONTRACTUAL_SALARY * employeeCalculate.WorkedDays);

            return salary;
        }
    }

    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeFactory() { }

        public decimal Calculate(EmployeeCalculateInput employeeCalculate)
        {
            decimal result = 0.00m;

           switch(Enum.ToObject(typeof(SproutEmployeeType),employeeCalculate.TypeId))
           {
                case SproutEmployeeType.Regular:
                    result = new RegularEmployee().Calculate(employeeCalculate);
                    break;
                case SproutEmployeeType.Contractual:
                    result = new ContractualEmloyee().Calculate(employeeCalculate);
                    break;

           }
           
            return result;
        }
    }
}
