import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Position } from "../position";
import { HttpClient } from '@angular/common/http';
import { AddEmployeePositionComponent } from '../add-employee-position/add-employee-position.component';
import { EmployeePosition } from '../employe-position';
import { EmployeePositionList } from '../employee-position-list/employee-position-list.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  @ViewChild(AddEmployeePositionComponent, { static: false })
  addEmployeePositionChild: AddEmployeePositionComponent;

  @ViewChild(EmployeePositionList, { static: false })
  employeePositionList: EmployeePositionList;

  positions: Position[] = [];
  employeePositions: EmployeePosition[] = [];
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.updateEmployeePositions();
    this.updatePositions();
  }

  onPositionCreated(newPosition: Position): void {
    //this.positions.push(newPosition);
    //this.addEmployeePositionChild.positions = this.positions;
    // ||
    this.updatePositions();
  }

  onEmployeePositionCreated(newEmployeePosition: EmployeePosition): void {
    //this.employeePositions.push(newEmployeePosition);
    //this.addEmployeePositionChild.positions = this.positions;
    // ||
    this.updateEmployeePositions();
  }

  private updatePositions(): void {
    this.http.get<Position[]>(this.baseUrl + "api/positions").subscribe(result => {
      this.positions = result;
      this.addEmployeePositionChild.positions = result;
    }, error => console.error(error));
  }
  private updateEmployeePositions(): void {
    this.http.get<EmployeePosition[]>(this.baseUrl + "api/employeepositions").subscribe(result => {
      console.log(result);
      this.employeePositions = result;
      this.employeePositionList.employeePositions = result;
    }, error => console.error(error));
  }
}
