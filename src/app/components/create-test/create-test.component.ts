import { Component, OnInit } from '@angular/core';
import { Test } from 'src/app/Models/Test';
import { UserService } from 'src/app/services/user.service';
import { ApiService } from 'src/app/services/api.service';
import { Class } from 'src/app/Models/Class';

@Component({
  selector: 'app-create-test',
  templateUrl: './create-test.component.html',
  styleUrls: ['./create-test.component.css']
})
export class CreateTestComponent implements OnInit {

  test:Test=new Test;
  constructor(private userService:UserService,private apiService:ApiService) {
    this.userService.getClassesForTeacher().subscribe(
      (res:Class[])=>userService.classesForTeacher=res,
      (err)=>console.log(err)
    );
    this.userService.getTestsForTeacher().subscribe(
      (res:Test[])=>this.userService.testsForTeacher=res,
      (err)=>console.log(err)
    );
   }

  ngOnInit() {
  }
  createTest(){
    this.apiService.createTest(this.test).subscribe(
      (res:Test)=>{
        this.userService.testsForTeacher.push(res);
        console.log(res)},
        (err)=>console.log(err)
    );
  }
}
