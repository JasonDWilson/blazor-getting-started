using BethanysPieShopHRM.App.Components;
using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverviewVirtual
    {
        private float itemHeight = 50;
        private int totalNumberOfEmployees = 1000;

        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        protected async override Task OnInitializedAsync() { Employees = await _employeeDataService.GetLongEmployeeList(); }

        public async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            var num = Math.Min(request.Count, totalNumberOfEmployees - request.StartIndex);
            var items = await _employeeDataService.GetLongEmployeeList(request.StartIndex, num);
            return new ItemsProviderResult<Employee>(items, totalNumberOfEmployees);
        }

        public IEnumerable<Employee> Employees { get; set; }
    }
}

