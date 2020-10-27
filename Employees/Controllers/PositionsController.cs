using Employees.Data.Models;
using Employees.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigin")]
    public class PositionsController
    {
        private readonly PositionRepository _positionRepository;
        public PositionsController(PositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // POST api/positions
        [HttpPost]
        public async Task<IActionResult> Post(Position position)
        {
            if (position == null)
            {
                return new BadRequestResult();
            }
            position = await _positionRepository.Add(position);
            return new OkObjectResult(position);
        }
    }
}