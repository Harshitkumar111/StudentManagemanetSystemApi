import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { studentmodel } from './student';


@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }
  readonly apiUrl = 'https://localhost:7140/api/Student/';

  getStudentList() {
    return this.http.get<any[]>(this.apiUrl);
  }
  deleteStuent(id: studentmodel) {
    return this.http.delete<number>(this.apiUrl +'/?id=' + id);
  }
  getByID(id :any)
  {
    return this.http.get<any>(this.apiUrl+"/GetByID?id=" + id);
  }
  updatestudent(data: studentmodel) {
    return this.http.put<any>(this.apiUrl,data );  
  }
  addstudent(data: studentmodel) {
    return this.http.post<any>(this.apiUrl , data);
  }
}
