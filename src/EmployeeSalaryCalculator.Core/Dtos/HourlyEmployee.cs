using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Dtos
{
    public class HourlyEmployee: IEmployee
    {
        public HourlyEmployee()
        {
            ContractTypeName = EmployeeContractType.HourlySalaryEmployee;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeContractType ContractTypeName { get; } 
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public long HourlySalary { get; set; }
        public long MonthlySalary { get; set; }
        public long AnnualSalary => 120 * HourlySalary * 12;
    }
}
