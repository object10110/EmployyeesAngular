using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employees.Data;
using Employees.Data.Models;
using Employees.Repositories;
using Microsoft.AspNetCore.Cors;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllOrigin")]
    public class EmployeePositionsController : ControllerBase
    {
        private readonly EmployeePositionsRepository _employeePositionsRepository;

        public EmployeePositionsController(EmployeePositionsRepository employeePositionsRepository)
        {
            _employeePositionsRepository = employeePositionsRepository;
        }

        // GET: api/EmployeePositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeePosition>>> GetEmployeePositions()
        {
            return await _employeePositionsRepository.GetAll();
        }

/*        // POST: api/EmployeePositions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeePosition>> PostEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePositions.Add(employeePosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeePosition", new { id = employeePosition.Id }, employeePosition);
        }

        private bool EmployeePositionExists(int id)
        {
            return _context.EmployeePositions.Any(e => e.Id == id);
        }*/
    }
}
