﻿using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected async override Task OnInitializedAsync() { Employees = await _employeeDataService.GetAllEmployeesAsync(); }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
