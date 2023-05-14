using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonnelSystem.Core.Models.Request;
using PersonnelSystem.Core.Models.Response;

namespace PersonnelSystem.Core.ServiceInterfaces
{
    public interface IPersonnelService
    {
        Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel requestModel);
        Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByManagerId(int managerId);

        Task<IEnumerable<ManagerResponseModel>> GetAllManagers();
        Task<IEnumerable<RoleResponseModel>> GetAllRoles();
    }
}
