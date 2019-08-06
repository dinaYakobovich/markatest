import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Student } from 'src/app/Models/Student';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-view-students',
  templateUrl: './view-students.component.html',
  styleUrls: ['./view-students.component.css']
})
export class ViewStudentsComponent implements OnInit {
  id:number;
  constructor(private router: ActivatedRoute, private apiService: ApiService) {
    this.router.params.subscribe(data => {
      this.id = +data['class_id'];
      this.apiService.getStudentsForClass(this.id).subscribe(
        (res: Student[]) => this.apiService.studentsForClass = res,
        (err) => console.log(err)
      );
    });
  }

  ngOnInit() {
  }
  deleteStudent(studentId:number){
    this.apiService.deleteStudent(studentId).subscribe(
      (res)=>{
        this.apiService.studentsForClass = this.apiService.studentsForClass.filter(item => item.userId !== studentId);
        new alert("deleted!!!");
      }
        ,
      (err)=>console.log(err)
    );
  }
}
