using Employees.Data;
using Employees.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Repositories
{
    public class EmployeePositionsRepository:BaseRepository<EmployeePosition, ApplicationDbContext>
    {
        public EmployeePositionsRepository(ApplicationDbContext context): base(context){}

        public override async Task<List<EmployeePosition>> GetAll()
        {
            var list = await base.GetAll();
            foreach (var item in list)
            {
                await _context.Entry(item).Reference(ep => ep.Employee).LoadAsync();
                await _context.Entry(item).Reference(ep => ep.Position).LoadAsync();
            }
            return list;
        }
    }
}