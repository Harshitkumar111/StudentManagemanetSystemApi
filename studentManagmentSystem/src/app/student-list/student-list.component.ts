import { Component,OnInit } from '@angular/core';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.css']
})
export class StudentListComponent implements OnInit {
  studentData !: any[] ;
  constructor(private service: StudentService){}
  
  ngOnInit(){
    this.refreshStudentList()
  }
  refreshStudentList() {
    this.service.getStudentList().subscribe((data => {
      this.studentData = data;
    }) ,
    (error)=>{
       alert("Please Check your Internet Connection")
    })  
  }
  deleteStudent(st:any){
    if (confirm('Are you sure??')) {
      this.service.deleteStuent(st.id).subscribe((data => {
        this.refreshStudentList();
      }) ,
      (error)=>{
         alert("Please Check your Internet Connection")
      })  
    }
  }
}
