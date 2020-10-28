import { Component, Input } from "@angular/core";
import { EmployeePosition } from "../employe-position";

@Component({
  selector: 'employee-position-list',
  templateUrl: './employee-position-list.component.html',
  styleUrls: ['./employee-position-list.component.css']
})
export class EmployeePositionList {
  @Input() employeePositions: EmployeePosition[] = [];
}
