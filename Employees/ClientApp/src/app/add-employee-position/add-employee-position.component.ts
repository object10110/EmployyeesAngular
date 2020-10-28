import { Component, OnInit, Inject, Input } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { EmployeePosition } from "../employe-position";
import { Position } from "../position";

@Component({
  selector: 'add-employee-position-component',
  templateUrl: './add-employee-position.component.html',
})
export class AddEmployeePositionComponent {
  employeePosition: EmployeePosition = new EmployeePosition();
  baseUrl: string;
  @Input() positions: Position[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.employeePosition.salary = 0;
  }

  addEmployeePosition(): void {
    console.log(this.employeePosition);
    this.http.post<EmployeePosition>(this.baseUrl + "api/employeepositions", this.employeePosition).subscribe(result => {
      console.log(result);
      //this.onPositionCreated.emit(result);
    }, error => console.error(error));
  }
}
