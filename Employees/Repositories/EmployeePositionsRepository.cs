using Employees.Data;
using Employees.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Repositories
{
    public class EmployeePositionsRepository:BaseRepository<EmployeePosition, ApplicationDbContext>
    {
        public EmployeePositionsRepository(ApplicationDbContext context): base(context){}

        public async Task<List<EmployeePosition>> GetAll(int page, int size)
        {
            var list = _context.EmployeePositions.Skip((page - 1) * size).Take(size).ToList();
            foreach (var item in list)
            {
                await _context.Entry(item).Reference(ep => ep.Employee).LoadAsync();
                await _context.Entry(item).Reference(ep => ep.Position).LoadAsync();
            }
            return list;
        }

        public async Task<int> Count()
        {
            return await _context.EmployeePositions.CountAsync();
        }
    }
}