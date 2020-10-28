import { Component, Input, Output, EventEmitter } from "@angular/core";
import { EmployeePositionPaginationList } from "../employee-position-pagination-list";

@Component({
  selector: 'employee-position-list',
  templateUrl: './employee-position-list.component.html',
  styleUrls: ['./employee-position-list.component.css']
})
export class EmployeePositionList {
  @Input() employeePositionPaginationList: EmployeePositionPaginationList
  @Output() onNextPage = new EventEmitter();
  @Output() onPreviousPage = new EventEmitter();

  nextPage(): void {
    this.onNextPage.emit();
  }

  previousPage(): void {
    this.onPreviousPage.emit();
  }
}
