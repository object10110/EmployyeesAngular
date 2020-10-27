using Employees.Data;
using Employees.Data.Models;

namespace Employees.Repositories
{
    public class EmployeesRepository:BaseRepository<Employee, ApplicationDbContext>
    {
        public EmployeesRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}