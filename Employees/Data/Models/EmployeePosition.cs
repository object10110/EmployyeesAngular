using System;

namespace Employees.Data.Models
{
    public class EmployeePosition
    {
        public int Id { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int? PositionId { get; set; }
        public Position Position { get; set; }

        public DateTime DateOfAppointment { get; set; }
        public DateTime? DateOfDismissal { get; set; }
    }
}