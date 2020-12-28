using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Services
{
    public interface IEmployeeDataService
    {
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeDetailsAsync(int employeeId);
        Task UpdateEmployeeAsync(Employee employee);
    }
}
