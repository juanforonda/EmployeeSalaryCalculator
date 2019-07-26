using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;

namespace EmployeeSalaryCalculator.Core.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeFactory employeeFactory)
        {
            _employeeRepository = employeeRepository;
            _employeeFactory = employeeFactory;
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();
            return employees.Select(e =>
            {
                var em = _employeeFactory.CreateEmployee(e.ContractTypeName);
                em.Id = e.Id;
                em.Name = e.Name;
                em.HourlySalary = e.HourlySalary;
                em.MonthlySalary = e.MonthlySalary;
                em.RoleDescription = e.RoleDescription;
                em.RoleId = e.RoleId;
                em.RoleName = e.RoleName;
                return em;
            });

        }

        public async Task<IEmployee> GetEmployeeById(int id)
        {
            var employees = await GetEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
            //var employees = await _employeeRepository.GetEmployees();
            //var employee = employees.FirstOrDefault(e => e.Id == id);

        }
    }
}
