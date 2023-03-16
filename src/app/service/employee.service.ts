import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateEmployee, Employee } from '../model/employee';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  addEmpUrl: string;
  getEmpUrl: string;
  updateEmpUrl: string;

  constructor(private http : HttpClient) {

    this.addEmpUrl = 'http://localhost:5222/api/v1/employee';
    this.getEmpUrl= 'http://localhost:5222/api/v1/employee';
    this.updateEmpUrl ='http://localhost:5222/api/v1/employee/';

   }
   
   addEmployee(emp : CreateEmployee){
    return this.http.post<CreateEmployee>(this.addEmpUrl,emp);
  }

  getAllEmployee(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.getEmpUrl);
  }
  
  updateEmployee(emp: Employee): Observable<Employee>{
   // console.log(emp.employeeID);
    var _url = this.updateEmpUrl.concat(emp.employeeID.toString());
    alert("Update successful");
    return this.http.put<Employee>(_url,emp);
  }
  deleteEmployee(id : number){
    return this.http.delete(`http://localhost:5222/api/v1/employee/${id}`);
  }
}
