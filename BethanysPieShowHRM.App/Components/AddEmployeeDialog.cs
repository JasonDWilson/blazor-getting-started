using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Components
{
    public partial class AddEmployeeDialog
    {
        [Inject]
        private IEmployeeDataService _employeeDataService { get; set; }

        public void Close()
        {
            IsShown = false;
            //StateHasChanged();
        }

        public void HandleInvalidSubmit()
        {

        }

        public async Task HandleValidSubmit()
        {
            await _employeeDataService.AddEmployee(Employee);
            IsShown = false;
            await NewEmployeeAddedEventCallback.InvokeAsync(true);
            //StateHasChanged();
        }

        public void ResetDialog()
        {
            Employee = new Employee
            {
                CountryId = 1,
                JobCategoryId = 1,
                BirthDate = DateTime.Now,
                JoinedDate = DateTime.Now
            };
        }

        public void Show()
        {
            IsShown = true;
            //StateHasChanged();
        }

        public Employee Employee
        {
            get;
            set;
        } = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

        public bool IsShown { get; set; }

        [Parameter]
        public EventCallback<bool> NewEmployeeAddedEventCallback { get; set; }
    }
}
