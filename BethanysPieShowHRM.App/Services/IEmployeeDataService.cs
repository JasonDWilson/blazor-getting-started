using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Services
{
    public interface IEmployeeDataService
    {
        Task<Employee> AddEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task<IEnumerable<Employee>> GetLongEmployeeList();
        Task<IEnumerable<Employee>> GetLongEmployeeList(int startIndex, int count);
        Task UpdateEmployee(Employee employee);
    }
}
