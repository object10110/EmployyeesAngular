import { EventEmitter, Component, ViewChild, ElementRef, Inject, Output } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Position } from "../position";

@Component ({
  selector: 'add-position-component',
  templateUrl: './add-position.component.html',
  styleUrls: ['./add-position.component.css']
})
export class AddPositionComponent {

  @ViewChild('closeAddPositionButton', { static: false })
  closebutton: ElementRef;
  position: Position;
  baseUrl: string;
  @Output() onPositionCreated = new EventEmitter<Position>();

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.position = new Position();
    this.position.name = "";
    this.baseUrl = baseUrl;
  }

  addPosition(): void {
    this.http.post<Position>(this.baseUrl + "api/positions", this.position).subscribe(result => {
      console.log(result);
      this.onPositionCreated.emit(result);
      this.closebutton.nativeElement.click();
      this.position.name = "";
    }, error => console.error(error));
  }
}
