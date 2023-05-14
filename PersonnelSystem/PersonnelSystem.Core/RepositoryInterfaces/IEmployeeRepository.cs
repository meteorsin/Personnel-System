using PersonnelSystem.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelSystem.Core.RepositoryInterfaces
{
    public interface IEmployeeRepository : IAsyncRepository<Entities.Employee>
    {
        Task<IEnumerable<Entities.Employee>> GetEmployeesByManagerId(int managerId);

        Task<IEnumerable<Entities.Employee>> GetAllManagers();
        Task<IEnumerable<Entities.Role>> GetAllRoles();
    }
}
