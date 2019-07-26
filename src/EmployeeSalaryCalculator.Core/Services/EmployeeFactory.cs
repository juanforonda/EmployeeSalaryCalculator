using System;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Dtos;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Services
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public IEmployee CreateEmployee(EmployeeContractType contractType)
        {
            switch (contractType)
            {
                case EmployeeContractType.HourlySalaryEmployee:
                    return new HourlyEmployee();
                case EmployeeContractType.MonthlySalaryEmployee:
                    return new MonthlyEmployee();
                default:
                    throw new ArgumentOutOfRangeException(nameof(contractType), contractType, "Contract type not supported.");
            }
        }
    }
}
