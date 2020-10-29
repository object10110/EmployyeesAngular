using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employees.Data.Models;
using Employees.Repositories;
using Employees.ModelsDTO;
using AutoMapper;
using System;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionsController : ControllerBase
    {
        private readonly int PAGE_SIZE = 5;
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

        // GET: api/EmployeePositions/GetByPage/{1}
        [Route("[action]/{page?}")]
        [HttpGet]
        public async Task<ActionResult<EmployeePositionPaginationList>> GetByPage(int page = 1)
        {

            var model = new EmployeePositionPaginationList();
            var epDtoList = new List<EmployeePositionDTO>();
            var epList = await _employeePositionsRepository.GetAll(page, PAGE_SIZE);

            foreach (var ep in epList)
            {
                epDtoList.Add(_mapper.Map<EmployeePositionDTO>(ep));
            }

            var countProducts = await _employeePositionsRepository.Count();
            var totalPages = (int)Math.Ceiling(countProducts / (double)PAGE_SIZE);

            if (page < 1) page = 1;
            if (page > totalPages) page = totalPages;

            model.EmployeePositions = epDtoList;
            model.CurrentPage = page;
            model.HasPrevious = page > 1;
            model.HasNext = totalPages > page;

            return model;
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
            return ep.PositionId > 0
                    && ep.DateOfAppointment.HasValue
                    && ep.Salary > 0
                    && !string.IsNullOrWhiteSpace(ep.Name)
                    && !string.IsNullOrWhiteSpace(ep.Surname)
                    && (!ep.DateOfDismissal.HasValue ||
                        ep.DateOfDismissal.HasValue && ep.DateOfAppointment.HasValue
                        && ep.DateOfDismissal.Value >= ep.DateOfAppointment.Value);
        }
    }
}