import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from '../student.service';
import { studentmodel } from '../student'; 
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-update-student',
  templateUrl: './add-update-student.component.html',
  styleUrls: ['./add-update-student.component.css']
})
export class AddUpdateStudentComponent implements OnInit {
  studentform !: FormGroup;
  value2: any;
  value = undefined;
  title!: string;
  edit!: string;
  buttonsave!: string;

  constructor(private service: StudentService , public activatedRoute:ActivatedRoute,private formbulider: FormBuilder, private router:Router){}
  
  ngOnInit() {
    this.value2 = this.activatedRoute.params;
    this.value = this.value2["_value"].id;
    this.studentform = this.formbulider.group({
      name:new FormControl('',[Validators.required,Validators.maxLength(10), Validators.pattern('^[a-zA-Z \-\']+')]),
      emailid:new FormControl('',[Validators.required,Validators.email,Validators.maxLength(20)]),
      phoneNo:new FormControl('',[Validators.required,Validators.minLength(10),Validators.maxLength(10),Validators.pattern('[- +()0-9]+')]),
      city:new FormControl('',[Validators.required,Validators.maxLength(10),Validators.pattern('^[a-zA-Z \-\']+')])
    })
 
    if(this.value != undefined){
      this.setdataedit();  
    }
  }
  save(data:any){
    this.service.addstudent(data).subscribe((res => {
      alert('Student Add successfully')
      this.router.navigate([''])
      // this.studentform.reset();  
    })  ,
    (error)=>{
       alert("Please Check your Internet Connection")
    })  
  }

  setdataedit(){
    this.service.getByID(this.value).subscribe((val) => {
    this.studentform.controls['name'].setValue(val[0].name);
    this.studentform.controls['emailid'].setValue(val[0].emailid);
    this.studentform.controls['phoneNo'].setValue(val[0].phoneNo);
    this.studentform.controls['city'].setValue(val[0].city);
    this.edit='0'
    })
  }
  updatedata(data:studentmodel){
    data.id = this.value;
    this.service.updatestudent(data).subscribe((res => {    
      alert('Student Update successfully')
      this.router.navigate([''])
     }) ,
     (error)=>{
        alert("Please Check your Internet Connection")
     })  
  }



  get err(){
    return this.studentform.controls;
  }
}
