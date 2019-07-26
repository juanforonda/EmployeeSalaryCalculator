using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;

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
            return employees?.Select(MapToConcreteEmployee);
        }


        public async Task<IEmployee> GetEmployeeById(int id)
        {
            var employees = await _employeeRepository.GetEmployees();
            var employee = employees?.FirstOrDefault(e => e.Id == id);
            return employee != null ? MapToConcreteEmployee(employee) : null;
        }
        private IEmployee MapToConcreteEmployee(Employee employee)
        {
            var concreteEmployee = _employeeFactory.CreateEmployee(employee.ContractTypeName);
            concreteEmployee.Id = employee.Id;
            concreteEmployee.Name = employee.Name;
            concreteEmployee.HourlySalary = employee.HourlySalary;
            concreteEmployee.MonthlySalary = employee.MonthlySalary;
            concreteEmployee.RoleDescription = employee.RoleDescription;
            concreteEmployee.RoleId = employee.RoleId;
            concreteEmployee.RoleName = employee.RoleName;
            return concreteEmployee;
        }

    }
}
