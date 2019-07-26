using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EmployeeSalaryCalculator.Core.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EmployeeContractType
    {
        HourlySalaryEmployee,
        MonthlySalaryEmployee
    }
}
