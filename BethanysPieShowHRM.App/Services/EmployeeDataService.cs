using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private HttpClient _httpClient;

        public EmployeeDataService(HttpClient client)
        { _httpClient = client ?? throw new ArgumentNullException(nameof(client)); }

        public Task<Employee> AddEmployeeAsync(Employee employee) { throw new NotImplementedException(); }

        public Task DeleteEmployeeAsync(int employeeId) { throw new NotImplementedException(); }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync(string.Empty),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetailsAsync(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(
                await _httpClient.GetStreamAsync($"{employeeId}"),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateEmployeeAsync(Employee employee) { throw new NotImplementedException(); }
    }
}
