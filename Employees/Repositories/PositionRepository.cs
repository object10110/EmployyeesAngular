using Employees.Data;
using Employees.Data.Models;

namespace Employees.Repositories
{
    public class PositionRepository : BaseRepository<Position, ApplicationDbContext>
    {
        public PositionRepository(ApplicationDbContext context): base(context)
        {

        }
    }
}