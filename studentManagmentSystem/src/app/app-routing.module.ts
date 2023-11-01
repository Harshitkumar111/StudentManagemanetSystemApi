import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './student-list/student-list.component';
import { AddUpdateStudentComponent } from './add-update-student/add-update-student.component';

const routes: Routes = [
  {
    path: '', component:StudentListComponent
  },
  {
    path: 'add', component:AddUpdateStudentComponent
  },
  {
    path: 'edit/:id', component:AddUpdateStudentComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
