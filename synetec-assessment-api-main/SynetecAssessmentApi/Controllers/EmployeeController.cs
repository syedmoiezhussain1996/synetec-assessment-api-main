using Microsoft.AspNetCore.Mvc;
using SynetecAssessmentApi.Services;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        public IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _employeeService.GetEmployeesAsync());
            }
            catch
            {
                return BadRequest("An error occurred.");
            }
        }

    }
}
