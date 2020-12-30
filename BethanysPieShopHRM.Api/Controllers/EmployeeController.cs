using BethanysPieShopHRM.Api.Models;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace BethanysPieShopHRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // save image
            if (!string.IsNullOrWhiteSpace(employee.ImageName) && employee.ImageContent != null && employee.ImageContent.Length > 0)
            {
                string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
                var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{employee.ImageName}";
                var fileStream = System.IO.File.Create(path);
                fileStream.Write(employee.ImageContent, 0, employee.ImageContent.Length);
                fileStream.Close();
                employee.ImageName = $"https://{currentUrl}/uploads/{employee.ImageName}";
            }


            var createdEmployee = _employeeRepository.AddEmployee(employee);

            return Created("employee", createdEmployee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
                return BadRequest();

            var employeeToDelete = _employeeRepository.GetEmployeeById(id);
            if (employeeToDelete == null)
                return NotFound();

            _employeeRepository.DeleteEmployee(id);

            return NoContent();//success
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        [HttpGet("long")]
        public IActionResult GetLongEmployeeList() =>
            Ok(_employeeRepository.GetLongEmployeeList());

        [HttpGet("long/{startIndex}/{count}")]
        public IActionResult GetLongEmployeeList(int startIndex, int count) =>
            Ok(_employeeRepository.GetLongEmployeeList(startIndex, count));

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            if (employee.FirstName == string.Empty || employee.LastName == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var employeeToUpdate = _employeeRepository.GetEmployeeById(employee.EmployeeId);

            if (employeeToUpdate == null)
                return NotFound();

            _employeeRepository.UpdateEmployee(employee);

            return NoContent(); //success
        }
    }
}
