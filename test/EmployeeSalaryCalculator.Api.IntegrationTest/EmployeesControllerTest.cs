using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace EmployeeSalaryCalculator.Api.IntegrationTest
{
    public class EmployeesControllerTest: IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public EmployeesControllerTest(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }
        [Fact]
        public async Task Success_GetEmployees_ReturnHttpOk()
        {
            var response = await _client.GetAsync("api/employees");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Success_GetEmployeeById_ReturnHttpOk()
        {
            var response = await _client.GetAsync("api/employees/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Success_GetEmployeeById_WhenTheEmployeeDoesNotExist_ReturnNotFound()
        {
            var response = await _client.GetAsync("api/employees/12345");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

    }
}
