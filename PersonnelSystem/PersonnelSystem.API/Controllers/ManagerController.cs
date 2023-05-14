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
    public class ManagerController : Controller
    {
        private readonly IPersonnelService _personnelService;

        public ManagerController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetManagers()
        {
            var res = await _personnelService.GetAllManagers();
            return Ok(res);
        }

        [HttpGet]
        [Route("{managerId:int}")]
        public async Task<IActionResult> GetEmployeesByManagerId(int managerId)
        {
            var res = await _personnelService.GetEmployeesByManagerId(managerId);
            if (res.Any())
            {
                return Ok(res);
            }
            return Ok(new Employee());
        }
    }
}
