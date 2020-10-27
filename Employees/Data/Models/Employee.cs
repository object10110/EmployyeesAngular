using System.Collections.Generic;

namespace Employees.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<EmployeePosition> Positions { get; set; }

        public Employee()
        {
            Positions = new List<EmployeePosition>(); 
        }
    }
}