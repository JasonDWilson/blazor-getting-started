using BethanysPieShopHRM.Shared;
using BethanysPieShowHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected async override Task OnInitializedAsync()
        { Employee = await _employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId)); }

        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string EmployeeId { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
