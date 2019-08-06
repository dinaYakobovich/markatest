import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { saveAs } from 'file-saver';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'testsClient';
  /**
   *
   */
  constructor(private http:HttpClient){}

  download(){
this.http.get(environment.api+'/student/generate',{ responseType: 'blob' }).subscribe((res)=>{
saveAs(res,'file.xlsx');
})

  }
}
