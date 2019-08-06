import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Class } from 'src/app/Models/Class';
import { Teacher } from 'src/app/Models/Teacher';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-classes',
  templateUrl: './view-classes.component.html',
  styleUrls: ['./view-classes.component.css']
})
export class ViewClassesComponent implements OnInit {
  classId:number;
  constructor(private userService:UserService,private router:Router) {
    userService.getClassesForTeacher().subscribe(
      (res:Class[])=>userService.classesForTeacher=res,
      (err)=>console.log(err)
    );
   }

  ngOnInit() {
  }

//   navigate(id){
// this.router.navigate(['/teachersettings/viewClasses/viewStudents/'+id]);
//   }

}
