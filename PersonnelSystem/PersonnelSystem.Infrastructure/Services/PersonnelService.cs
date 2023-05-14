using PersonnelSystem.Core.ServiceInterfaces;
using PersonnelSystem.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonnelSystem.Core.Models.Response;
using PersonnelSystem.Core.Models.Request;
using PersonnelSystem.Core.Entities;

namespace PersonnelSystem.Infrastructure.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly IEmployeeRepository _personnelRepository;

        public PersonnelService(IEmployeeRepository repository)
        {
            _personnelRepository = repository;
        }

        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel requestModel)
        {
            if (requestModel.ManagerId == 0)
            {
                requestModel.ManagerId = null;
            }
            var employee = new Employee
            {
                ManagerId = requestModel.ManagerId,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Roles = requestModel.Roles
            };
            var newEmployee = await _personnelRepository.AddAsync(employee);
            var response = new EmployeeResponseModel
            {
                Id = newEmployee.Id,
                ManagerId = newEmployee.ManagerId,
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Roles = newEmployee.Roles,
            };
            return response;
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetEmployeesByManagerId(int managerId)
        {
            var employees = await _personnelRepository.GetEmployeesByManagerId(managerId);
            var response = new List<EmployeeResponseModel>();
            if (!employees.Any())
            {
                return response;
            }
            foreach (var employee in employees)
            {
                response.Add(new EmployeeResponseModel
                {
                    Id = employee.Id,
                    ManagerId = employee.ManagerId,
                    LastName = employee.LastName,
                    FirstName = employee.FirstName,
                    Roles = employee.Roles
                });
            }
            return response;
        }

        public async Task<IEnumerable<ManagerResponseModel>> GetAllManagers()
        {
            var managers = await _personnelRepository.GetAllManagers();
            var response = new List<ManagerResponseModel>();
            if (!managers.Any())
            {
                return response;
            }
            foreach (var manager in managers)
            {
                response.Add(new ManagerResponseModel
                {
                    Id = manager.Id,
                    Name = manager.FirstName + " " +manager.LastName,
                });
            }
            return response;
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRoles()
        {
            var roles = await _personnelRepository.GetAllRoles();
            var response = new List<RoleResponseModel>();
            if (!roles.Any())
            {
                return response;
            }
            foreach (var r in roles)
            {
                response.Add(new RoleResponseModel
                {
                    Id = r.Id,
                    RoleName = r.RoleName
                });
            }
            return response;
        }
    }
}
