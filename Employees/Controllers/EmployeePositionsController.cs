using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employees.Data.Models;
using Employees.Repositories;
using Employees.ModelsDTO;
using AutoMapper;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EmployeePositionsRepository _employeePositionsRepository;
        private readonly PositionRepository _positionRepository;
        private readonly EmployeesRepository _employeesRepository;

        public EmployeePositionsController(IMapper mapper, EmployeePositionsRepository employeePositionsRepository,
            PositionRepository positionRepository, EmployeesRepository employeesRepository)
        {
            _mapper = mapper;
            _employeePositionsRepository = employeePositionsRepository;
            _positionRepository = positionRepository;
            _employeesRepository = employeesRepository;
        }

        // GET: api/EmployeePositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeePosition>>> Get()
        {
            return await _employeePositionsRepository.GetAll();
        }

        // POST: api/EmployeePositions
        [HttpPost]
        public async Task<EmployeePositionDTO> Post(EmployeePositionDTO employeePosition)
        {
            if (employeePosition != null)
            {
                if (IsValid(employeePosition))
                {
                    var finedPosition = await _positionRepository.Get(employeePosition.PositionId);
                    if (finedPosition != null)
                    {
                        var finedEmployee = await _employeesRepository.GetBy(employeePosition.Name, employeePosition.Surname);
                        if (finedEmployee == null)
                        {
                            finedEmployee = new Employee()
                            {
                                Name = employeePosition.Name,
                                Surname = employeePosition.Surname
                            };
                            finedEmployee = await _employeesRepository.Add(finedEmployee);
                        }

                        var newEmployeePosition = _mapper.Map<EmployeePosition>(employeePosition);

                        newEmployeePosition.PositionId = finedPosition.Id;
                        newEmployeePosition.Position = finedPosition;
                        newEmployeePosition.EmployeeId = finedEmployee.Id;
                        newEmployeePosition.Employee = finedEmployee;

                        newEmployeePosition = await _employeePositionsRepository.Add(newEmployeePosition);

                        employeePosition = _mapper.Map<EmployeePositionDTO>(newEmployeePosition);

                        return employeePosition;
                    }
                }
            }
            Response.StatusCode = 400;
            return null;
        }

        private bool IsValid(EmployeePositionDTO ep)
        {
            return ep.PositionId > 0 && ep.DateOfAppointment.HasValue && ep.Salary > 0
                    && !string.IsNullOrWhiteSpace(ep.Name) && !string.IsNullOrWhiteSpace(ep.Surname);
        }
    }
}
