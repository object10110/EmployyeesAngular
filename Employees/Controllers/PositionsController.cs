using AutoMapper;
using Employees.Data.Models;
using Employees.ModelsDTO;
using Employees.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PositionRepository _positionRepository;
        public PositionsController(IMapper mapper, PositionRepository positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PositionDTO>> Get()
        {
            var positionDtoList = new List<PositionDTO>();
            var positionList = await _positionRepository.GetAll();
            foreach (var position in positionList)
            {
                positionDtoList.Add(_mapper.Map<PositionDTO>(position));
            }
            return positionDtoList;
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
            Response.StatusCode = 400;
            return null;
        }
    }
}