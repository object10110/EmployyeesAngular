import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Position } from "../position";
import { HttpClient } from '@angular/common/http';
import { AddEmployeePositionComponent } from '../add-employee-position/add-employee-position.component';
import { EmployeePosition } from '../employe-position';
import { EmployeePositionList } from '../employee-position-list/employee-position-list.component';
import { EmployeePositionPaginationList } from '../employee-position-pagination-list';

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
  employeePositionPaginationList: EmployeePositionPaginationList;
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.employeePositionPaginationList = new EmployeePositionPaginationList();
    this.employeePositionPaginationList.employeePositions = [];
    this.employeePositionPaginationList.currentPage = 1;
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

  onNextPage(): void {
    if (this.employeePositionPaginationList.hasNext) {
      this.employeePositionPaginationList.currentPage++;
      this.updateEmployeePositions();
    }
  }

  onPreviousPage(): void {
    if (this.employeePositionPaginationList.hasPrevious) {
      this.employeePositionPaginationList.currentPage--;
      this.updateEmployeePositions();
    }
  }

  private updatePositions(): void {
    this.http.get<Position[]>(this.baseUrl + "api/positions").subscribe(result => {
      this.positions = result;
      this.addEmployeePositionChild.positions = result;
    }, error => console.error(error));
  }
  private updateEmployeePositions(): void {
    this.http.get<EmployeePositionPaginationList>(this.baseUrl +
      "api/employeepositions/getbypage/" + this.employeePositionPaginationList.currentPage)
      .subscribe(result => {
        console.log(result);
        this.employeePositionPaginationList = result;
        this.employeePositionList.employeePositionPaginationList.employeePositions = result.employeePositions;
      }, error => console.error(error));
  }
}
