using System;

namespace Employees.ModelsDTO
{
    public class EmployeePositionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int EmployeeId { get; set; }

        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public decimal Salary { get; set; }

        public DateTime? DateOfAppointment { get; set; }
        public DateTime? DateOfDismissal { get; set; }
    }
}