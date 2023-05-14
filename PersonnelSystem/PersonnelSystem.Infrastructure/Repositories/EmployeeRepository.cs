using Microsoft.EntityFrameworkCore;
using PersonnelSystem.Core.Entities;
using PersonnelSystem.Core.RepositoryInterfaces;
using PersonnelSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonnelSystem.Infrastructure.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PersonnelDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Employee>> GetEmployeesByManagerId(int managerId)
        {
            var t = _dbContext.Employees.Where(g => g.ManagerId == managerId);
            var employees = await t.ToListAsync();
            return employees;
        }

        public async Task<IEnumerable<Employee>> GetAllManagers()
        {
            var t = _dbContext.Employees.Where(g =>!g.ManagerId.HasValue );
            return await t.ToListAsync();
        }

        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            return await _dbContext.Roles.ToListAsync();
        }
    }

}
