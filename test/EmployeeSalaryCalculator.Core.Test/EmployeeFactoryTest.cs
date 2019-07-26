using System;
using System.Collections.Generic;
using System.Text;
using EmployeeSalaryCalculator.Core.Dtos;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using FluentAssertions;
using Xunit;

namespace EmployeeSalaryCalculator.Core.Test
{
    public class EmployeeFactoryTest
    {
        [Fact]
        public void CanCreateMonthlyEmployeeObject()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var monthlyEmployee = employeeFactory.CreateEmployee(EmployeeContractType.MonthlySalaryEmployee);

            //Assert
            monthlyEmployee.Should().BeOfType<MonthlyEmployee>();
        }

        [Fact]
        public void CanCreateHourlyEmployeeObject()
        {
            //Arrange
            var employeeFactory = new EmployeeFactory();

            //Act
            var hourlyEmployee = employeeFactory.CreateEmployee(EmployeeContractType.HourlySalaryEmployee);

            //Assert
            hourlyEmployee.Should().BeOfType<HourlyEmployee>();
        }
    }
}
