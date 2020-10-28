using Employees.Data;
using Employees.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Employees.Repositories
{
    public class EmployeesRepository:BaseRepository<Employee, ApplicationDbContext>
    {
        public EmployeesRepository(ApplicationDbContext context): base(context)
        {

        }
        public async Task<Employee> GetBy(string name, string surname)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Name.ToLower().Equals(name.ToLower())
                                                        && e.Surname.ToLower().Equals(surname.ToLower()));
        }
    }
}