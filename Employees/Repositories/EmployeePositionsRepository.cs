using Employees.Data;
using Employees.Data.Models;

namespace Employees.Repositories
{
    public class EmployeePositionsRepository:BaseRepository<EmployeePosition, ApplicationDbContext>
    {
        public EmployeePositionsRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}