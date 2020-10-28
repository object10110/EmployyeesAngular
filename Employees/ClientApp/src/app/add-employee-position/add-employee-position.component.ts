import { Component, OnInit, Inject, Input, Output, EventEmitter, ViewChild, ElementRef } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { EmployeePosition } from "../employe-position";
import { Position } from "../position";

@Component({
  selector: 'add-employee-position-component',
  templateUrl: './add-employee-position.component.html',
  styleUrls: ['./add-employee-position.component.css']
})
export class AddEmployeePositionComponent {
  @ViewChild('closeAddEmployeePositionButton', { static: false })
  closebutton: ElementRef;

  errMessage: string;
  employeePosition: EmployeePosition = new EmployeePosition();
  baseUrl: string;
  @Input() positions: Position[];
  @Output() onEmployeePositionCreated = new EventEmitter<EmployeePosition>();

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.employeePosition.salary = 0;
  }

  addEmployeePosition(): void {
    console.log(this.employeePosition);
    this.errMessage = this.getError();
    if (this.errMessage == "") {
      this.http.post<EmployeePosition>(this.baseUrl + "api/employeepositions", this.employeePosition).subscribe(result => {
        this.onEmployeePositionCreated.emit(result);
        this.closebutton.nativeElement.click();
        this.employeePosition = new EmployeePosition();
        this.employeePosition.salary = 0;
      }, error => console.error(error));
    }
  }

  getError(): string {
    if (!(this.employeePosition.surname) || this.employeePosition.surname.length <= 0) return "Заполните поле Фамилия";
    if (!(this.employeePosition.name) || this.employeePosition.name.length <= 0) return "Заполните поле Имя";
    if (!(this.employeePosition.positionId) || this.employeePosition.positionId <= 0) return "Выберите должность";
    if (!(this.employeePosition.salary) || this.employeePosition.salary <= 0) return "Оклад должен быть больше 0";
    if (!this.employeePosition.dateOfAppointment) return "Укажите дату найма";
    return "";
  }
}
