using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PersonnelSystem.Core.Models.Request;
using PersonnelSystem.Core.RepositoryInterfaces;
using PersonnelSystem.Core.ServiceInterfaces;
using PersonnelSystem.Core.Entities;
using PersonnelSystem.Infrastructure.Repositories;
using System.Linq;

namespace PersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IPersonnelService _personnelService;

        public EmployeeController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }


        [HttpPost("addEmployee")]
        public async Task<ActionResult> RegisterEmployeeAsync([FromBody] EmployeeRequestModel t)
        {
            var addEmployee = await _personnelService.AddEmployee(t);
            return CreatedAtRoute("AddEmployee", new { id = addEmployee.Id }, addEmployee);
        }

        [HttpGet]
        [Route("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var res = await _personnelService.GetAllRoles();
            return Ok(res);
        }
    }
}
