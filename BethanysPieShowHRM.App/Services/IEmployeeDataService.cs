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
        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task UpdateEmployee(Employee employee);
    }
}
