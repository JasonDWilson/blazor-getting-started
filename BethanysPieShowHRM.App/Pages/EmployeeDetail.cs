using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.ComponentsLibrary.Map;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await _employeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            MapMarkers.Add(new Marker
            {
                Description = $"{Employee.FirstName} {Employee.LastName}",
                ShowPopup = false,
                X = Employee.Longitude,
                Y = Employee.Latitude
            });
        }

        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string EmployeeId { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();
    }
}
