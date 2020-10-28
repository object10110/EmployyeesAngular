import { EmployeePosition } from "./employe-position";

export class EmployeePositionPaginationList {
  employeePositions: Array<EmployeePosition>;
  currentPage: number;
  hasNext: boolean;
  hasPrevious: boolean;
}
