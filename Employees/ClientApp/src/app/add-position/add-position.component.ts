import { EventEmitter, Component, ViewChild, ElementRef, Inject } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Position } from "../position";

@Component ({
  selector: 'add-position-component',
  templateUrl: './add-position.component.html',
})
export class AddPositionComponent {

  @ViewChild('closeAddPositionButton', { static: false })
  closebutton: ElementRef;

  position: Position;
  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.position = new Position();
    this.position.name = "1";
    this.baseUrl = baseUrl;
  }

  addPosition(): void {
    console.log(this.position);
    console.log(this.baseUrl + "api/positions");
    this.http.post(this.baseUrl + "api/positions", this.position).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
    this.closebutton.nativeElement.click();
    this.position.name = "";
  }
}
