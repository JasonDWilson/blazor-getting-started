using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.Api.Models
{
    public interface IEmployeeRepository
    {
        Employee AddEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int employeeId);
        IEnumerable<Employee> GetLongEmployeeList();
        IEnumerable<Employee> GetLongEmployeeList(int startIndex, int count);
        Employee UpdateEmployee(Employee employee);
    }
}
