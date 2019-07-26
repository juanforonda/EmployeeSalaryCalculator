using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        EmployeeContractType ContractTypeName { get; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        long HourlySalary { get; set; }
        long MonthlySalary { get; set; }
        long AnnualSalary { get; }
    }
}
