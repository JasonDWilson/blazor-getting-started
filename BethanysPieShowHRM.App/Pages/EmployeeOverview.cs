﻿using BethanysPieShopHRM.Shared;
using BethanysPieShowHRM.App.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShowHRM.App.Pages
{
    public partial class EmployeeOverview
    {
        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        private List<Country> Countries { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        protected async override Task OnInitializedAsync() { Employees = await _employeeDataService.GetAllEmployees(); }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
