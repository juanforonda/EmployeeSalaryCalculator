using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;
using EmployeeSalaryCalculator.Core.Services;
using Newtonsoft.Json;
using Xunit;

namespace EmployeeSalaryCalculator.Core.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees");
            response.EnsureSuccessStatusCode();
            var employee =  JsonConvert.DeserializeObject<IEnumerable<Employee>>(await response.Content.ReadAsStringAsync());
            var factory = new EmployeeFactory();
            var employee2 = employee.Select(e =>
            {
                var em = factory.CreateEmployee(e.ContractTypeName);
                em.RoleDescription = e.RoleDescription;
                em.RoleId = e.RoleId;
                em.RoleName = e.RoleName;
                return em;
            }).ToList();
            employee2.Count();
        }
    }
}
