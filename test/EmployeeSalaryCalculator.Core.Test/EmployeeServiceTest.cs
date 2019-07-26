using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Dtos;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace EmployeeSalaryCalculator.Core.Test
{
    public class EmployeeServiceTest
    {
        [Fact]
        public void AnnualSalaryCalculated_WhenTheEmployeeHasMonthlyContract()
        {
            //formula to calculate annual salary to MonthlyEmployee MonthlySalary * 12
            //Arrange
            const long annualSalaryExpected = 960000;
            var monthlyEmployee = new MonthlyEmployee
            {
                Id = 1,
                Name = "Juan",
                MonthlySalary = 80000,
                RoleId = 1,
                RoleName = "Administrator"
            };
            //Assert
            monthlyEmployee.AnnualSalary.Should().Be(annualSalaryExpected);
        }

        [Fact]
        public void AnnualSalaryCalculated_WhenTheEmployeeHasHourlyContract()
        {
            //formula to calculate annual salary to HourlyEmployee 120 * HourlySalary * 12
            //Arrange
            const long annualSalaryExpected = 72000;
            var monthlyEmployee = new HourlyEmployee
            {
                Id = 1,
                Name = "Juan",
                HourlySalary = 50,
                RoleId = 1,
                RoleName = "Administrator"
            };
            //Assert
            monthlyEmployee.AnnualSalary.Should().Be(annualSalaryExpected);
        }

        [Fact]
        public async Task SuccessGettingEmployees()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var expectedListResponse = new List<IEmployee>
            {
                new HourlyEmployee() {Id = 1, HourlySalary = 50, MonthlySalary = 6000, Name = "Juan", RoleId = 1, RoleName = "Administrator"},
                new MonthlyEmployee() {Id = 2, HourlySalary = 50, MonthlySalary = 6000, Name = "Diego", RoleId = 1, RoleName = "Administrator"}
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseListOfEmployees =  await employeeService.GetEmployees();

            //Assert
            responseListOfEmployees.Should().BeEquivalentTo(expectedListResponse);
        }


        [Fact]
        public async Task SuccessGettingEmployeeById()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var expectedResponse = new HourlyEmployee()
            {
                Id = 1, HourlySalary = 50, MonthlySalary = 6000, Name = "Juan", RoleId = 1, RoleName = "Administrator"
            };

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseEmployee = await employeeService.GetEmployeeById(1);

            //Assert
            responseEmployee.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GettingEmployeeById_WhenTheEmployeeDoesNotExist_ReturnNull()
        {
            //Arrange
            var employees = GetFakeDataEmployees();
            var employeesRepository = new Mock<IEmployeeRepository>();
            employeesRepository.Setup(repo => repo.GetEmployees()).ReturnsAsync(employees);

            var employeeService = new EmployeeService(employeesRepository.Object, new EmployeeFactory());

            //Act
            var responseEmployee = await employeeService.GetEmployeeById(3);

            //Assert
            responseEmployee.Should().BeNull();
        }

        private static List<Employee> GetFakeDataEmployees()
        {
            return new List<Employee>
            {
                new Employee {ContractTypeName = EmployeeContractType.HourlySalaryEmployee, Id = 1, HourlySalary = 50, MonthlySalary = 6000, Name = "Juan", RoleId = 1, RoleName = "Administrator"},
                new Employee {ContractTypeName = EmployeeContractType.MonthlySalaryEmployee, Id = 2, HourlySalary = 50, MonthlySalary = 6000, Name = "Diego", RoleId = 1, RoleName = "Administrator"}
            };
        }
    }
}
