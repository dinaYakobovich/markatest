import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule }from'@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { UserService } from './services/user.service';
import { HttpClientModule } from '@angular/common/http';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { TeacherSettingsComponent } from './components/teacher-settings/teacher-settings.component';
import { StudentHomeComponent } from './components/student-home/student-home.component';
import { AddSubjectComponent } from './components/add-subject/add-subject.component';
import { AddSubThemeComponent } from './components/add-sub-theme/add-sub-theme.component';
import { AddGroupComponent } from './components/add-group/add-group.component';
import { AddQuestionComponent } from './components/add-question/add-question.component';
import { AddPupilsComponent } from './components/add-pupils/add-pupils.component';
import { CreateTestComponent } from './components/create-test/create-test.component';
import { CookieService } from 'ngx-cookie-service';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ViewStudentsComponent } from './components/view-students/view-students.component';
import { ViewClassesComponent } from './components/view-classes/view-classes.component';
import { ViewQuestionsComponent } from './components/view-questions/view-questions.component';
import { ViewTestsComponent } from './components/view-tests/view-tests.component';
import { MyProfileComponent } from './components/my-profile/my-profile.component';
import { ViewSubjectsComponent } from './components/view-subjects/view-subjects.component';
import { ViewSubThemesComponent } from './components/view-sub-themes/view-sub-themes.component';
import { SolveTestComponent } from './components/solve-test/solve-test.component';
import { EditStudentComponent } from './components/edit-student/edit-student.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ViewStudentComponent } from './components/view-student/view-student.component';

//import {MatInputModule} from '@angular/material/input';
@NgModule({
  declarations: [
    AppComponent,
    SignInComponent,
    SignUpComponent,
    ForgotPasswordComponent,
    TeacherSettingsComponent,
    StudentHomeComponent,
    AddSubjectComponent,
    AddSubThemeComponent,
    AddGroupComponent,
    AddQuestionComponent,
    AddPupilsComponent,
    CreateTestComponent,
    NavbarComponent,
    ViewStudentsComponent,
    ViewClassesComponent,
    ViewQuestionsComponent,
    ViewTestsComponent,
    MyProfileComponent,
    ViewSubjectsComponent,
    ViewSubThemesComponent,
    SolveTestComponent,
    EditStudentComponent,
    ViewStudentComponent
  ],
  imports: [
    //MatInputModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [UserService,CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
