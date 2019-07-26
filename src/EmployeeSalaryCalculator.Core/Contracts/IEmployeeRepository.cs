using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Models;

namespace EmployeeSalaryCalculator.Core.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
