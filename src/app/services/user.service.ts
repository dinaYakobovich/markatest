import { Injectable } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';  
import { environment } from 'src/environments/environment';
import { Teacher } from '../Models/Teacher';
import { Category } from '../Models/Category';
import { Class } from '../Models/Class';
import { Test } from '../Models/Test';
import { Question } from '../Models/Question';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  user:any;
  categoriesForTeacher:Category[];
  classesForTeacher:Class[];
  testsForTeacher:Test[];
  questionsForTeacher:Question[];
  constructor(private http:HttpClientModule, private httpService:HttpClient) { }
  ngOnInit(){
    
  }
  getUser(name:string,password:string){
    return this.httpService.get(environment.api+'/User/signIn?name='+name+'&password='+password);
  }
  addUser(teacher:Teacher){
    return this.httpService.post(environment.api + '/User/signUp', teacher);
  }
  getCategoriesForTeacher(){
    return this.httpService.get(environment.api+'/Category/getCategoriesForTeacher?teacherId='+(this.user as Teacher).teacherId);
  }
  getClassesForTeacher(){
    return this.httpService.get(environment.api+'/Class/getClassesForTeacher?teacherId='+(this.user as Teacher).teacherId);
  }
  getTestsForTeacher(){
    return this.httpService.get(environment.api+'/Test/getTestsForTeacher?teacherId='+(this.user as Teacher).teacherId);
  }
}