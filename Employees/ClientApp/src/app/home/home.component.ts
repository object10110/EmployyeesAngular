import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Position } from "../position";
import { HttpClient } from '@angular/common/http';
import { AddEmployeePositionComponent } from '../add-employee-position/add-employee-position.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  @ViewChild(AddEmployeePositionComponent, { static: false }) addEmployeePositionChild: AddEmployeePositionComponent;
  positions: Position[] = [];
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  ngOnInit() {
    this.updatePositions();
  }

  onPositionCreated(newPosition: Position): void {
    //this.positions.push(newPosition);
    //this.addEmployeePositionChild.positions = this.positions;
    // ||
    this.updatePositions();
  }

  private updatePositions(): void {
    this.http.get<Position[]>(this.baseUrl + "api/positions").subscribe(result => {
      this.positions = result;
      this.addEmployeePositionChild.positions = result;
    }, error => console.error(error));
  }
}
