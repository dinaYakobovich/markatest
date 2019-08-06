import { Injectable } from '@angular/core';
import { Sub_category } from '../Models/Sub_category';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Category } from '../Models/Category';
import { Class } from '../Models/Class';
import { Student } from '../Models/Student';
import { Test } from '../Models/Test';
import { Type } from '../Models/Type';
import { Question } from '../Models/Question';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  subCategory: Sub_category = new Sub_category();
  studentsForClass: Student[];
  types:Type[];
  constructor(private http: HttpClientModule, private httpService: HttpClient) { 
    this.getTypes().subscribe(
      (res:Type[])=>this.types=res,
      (err)=>console.log(err)
    );
  }
  getTypes(){
    return this.httpService.get(environment.api+'/Type/getTypes');
  }
  addCategory(category: Category) {
    return this.httpService.post(environment.api + '/Category/addCategory', category);
  }
  addSubCategory(subCategory: Sub_category) {
    return this.httpService.post(environment.api + '/SubCategory/addSubCategory', subCategory);
  }
  addClass(cls: Class) {
    return this.httpService.post(environment.api + '/Class/addClass', cls);
  }
  postFile(file:File,classId:number) {
    // const endpoint = 'environment.api';
    debugger
    const formData: FormData = new FormData();
    formData.append('uploadFile', file, file.name);
    return this.httpService
      .post(environment.api + '/Student/addStudents?classId='+classId, formData);
    // .map(() => { return true; })
    // .catch((e) => this.handleError(e));
  }
  addStudent(student: Student) {
    return this.httpService.post(environment.api + '/Student/addStudent', student);
  }
  getSubCategoriesForCat(categoryId: number) {
    return this.httpService.get(environment.api + '/SubCategory/getSubCategoriesForCategory?categoryId=' + categoryId);
  }
  createTest(test:Test){
    return this.httpService.post(environment.api+'/Test/addTest',test);
  }
  forgotPassword(emailAddress:string){
    return this.httpService.get(environment.api+'/User/forgotPassword?emailAddress='+emailAddress);
  }
  getStudentsForClass(class_id:number){
    return this.httpService.get(environment.api+'/Class/getStudentsForClass?classId='+class_id);
  }
  deleteStudent(studentId:number){
    return this.httpService.get(environment.api+'/Student/deleteStudent?studentId='+studentId);
  }
  editStudent(student:Student){
    return this.httpService.post(environment.api+'/Student/editStudent',student);
  }
  addQuestion(question:Question){
    return this.httpService.post(environment.api+'/Question/addQuestion',question);
  }
}