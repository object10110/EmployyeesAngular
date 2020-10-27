using System.Collections.Generic;

namespace Employees.Data.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<EmployeePosition> EmployeePositions { get; set; }
    }
}