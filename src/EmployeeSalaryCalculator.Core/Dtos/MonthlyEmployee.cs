using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Dtos
{
    public class MonthlyEmployee: IEmployee
    {
        public MonthlyEmployee()
        {
            ContractTypeName = EmployeeContractType.MonthlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractType ContractTypeName { get; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public long HourlySalary { get; set; }
        public long MonthlySalary { get; set; }
        public long AnnualSalary => MonthlySalary * 12;
    }
}
