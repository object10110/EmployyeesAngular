using System.Collections.Generic;

namespace Employees.ModelsDTO
{
    public class EmployeePositionPaginationList
    {
        public IEnumerable<EmployeePositionDTO> EmployeePositions { get; set; }
        public int CurrentPage { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
    }
}
