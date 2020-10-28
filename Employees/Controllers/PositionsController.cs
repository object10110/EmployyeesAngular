using AutoMapper;
using Employees.Data.Models;
using Employees.ModelsDTO;
using Employees.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController
    {
        private readonly IMapper _mapper;
        private readonly PositionRepository _positionRepository;
        public PositionsController(IMapper mapper, PositionRepository positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        [HttpGet]
        public bool Get()
        {
            return true;
        }

        // POST api/positions
        [HttpPost]
        public async Task<PositionDTO> Post(PositionDTO position)
        {
            if (position != null)
            {
                try
                {
                    var newPosition = _mapper.Map<Position>(position);
                    newPosition = await _positionRepository.Add(newPosition);
                    position = _mapper.Map<PositionDTO>(newPosition);
                    return position;
                }
                catch { };
            }
            return null;
        }
    }
}