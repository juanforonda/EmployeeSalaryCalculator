using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeSalaryCalculator.Core.Contracts;
using EmployeeSalaryCalculator.Core.Models;
using Newtonsoft.Json;

namespace EmployeeSalaryCalculator.Data
{
    public class EmployeeApiRepository: IEmployeeRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeApiRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var httpClient = _httpClientFactory.CreateClient("EmployeeService");
            var response = await httpClient.GetAsync("Employees");
            response.EnsureSuccessStatusCode();
            return  JsonConvert.DeserializeObject<IEnumerable<Employee>>(await response.Content.ReadAsStringAsync());
        }
    }
}
