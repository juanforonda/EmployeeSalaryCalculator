using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(EmployeeContractType employeeContractType);
    }
}
