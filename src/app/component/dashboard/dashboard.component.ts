import { Component, OnInit } from '@angular/core';
import{FormGroup, FormBuilder, FormControl} from '@angular/forms'
import { Employee } from 'src/app/model/employee';
import { CreateEmployee } from 'src/app/model/employee';
import { EmployeeService } from 'src/app/service/employee.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  empDetail!: FormGroup;
  empObj: CreateEmployee = new CreateEmployee();
  empObj1: Employee = new Employee();
  empList : Employee[] = [];
  etype: string[] = ["Internal","External"];
  constructor(private formBuilder : FormBuilder, private empService : EmployeeService){}

  ngOnInit(): void {
    
    this.getAllEmployee();
    this.empDetail = this.formBuilder.group ({
      employeeID :[''],
      employeeName : [''],
      employeeType : [''],
      gender: [''],
      role: [''],
      skills: [''],
      division: ['']
    });
  }
  addEmployee(){
    console.log('hello ',this.empDetail);
    this.empObj.employeeName = this.empDetail.value.employeeName;
    this.empObj.employeeType = this.empDetail.value.employeeType;
    this.empObj.gender = this.empDetail.value.gender;
    this.empObj.role = this.empDetail.value.role;
    this.empObj.skills = this.empDetail.value.skills;
    this.empObj.division = this.empDetail.value.division;

    this.empService.addEmployee(this.empObj).subscribe(res=>{
      console.log(res);
      this.getAllEmployee();
      this.empDetail.reset();

    },err =>{
        console.log(err);
    });

  }

  getAllEmployee(){
      this.empService.getAllEmployee().subscribe(res=>{
        this.empList = res;
      },err=>{
        console.log("error while fetching data.")
      });
  }

  editEmployee(emp : Employee){
    this.empDetail.controls['employeeID'].setValue(emp.employeeID);
    this.empDetail.controls['employeeName'].setValue(emp.employeeName);
    this.empDetail.controls['employeeType'].setValue(emp.employeeType);
    this.empDetail.controls['gender'].setValue(emp.gender);
    this.empDetail.controls['role'].setValue(emp.role);
    this.empDetail.controls['skills'].setValue(emp.skills);
    this.empDetail.controls['division'].setValue(emp.division);
  }

  updateEmployee(){
    console.log("hello + ");
    this.empObj1.employeeID = this.empDetail.value.employeeID;
    this.empObj1.employeeName = this.empDetail.value.employeeName;
    this.empObj1.employeeType = this.empDetail.value.employeeType;
    this.empObj1.gender = this.empDetail.value.gender;
    this.empObj1.role = this.empDetail.value.role;
    this.empObj1.skills = this.empDetail.value.skills;
    this.empObj1.division = this.empDetail.value.division;

    console.log("hellotest" + this.empDetail.value.employeeName);

    this.empService.updateEmployee(this.empObj1).subscribe(res=>{
      console.log(res);
      this.getAllEmployee();
    },err=>{
      console.log(err);
    })
  }
  
  deleteEmployee(emp: Employee){
    this.empDetail.controls['employeeID'].setValue(emp.employeeID);
    this.empService.deleteEmployee(emp.employeeID).subscribe(res=>{
      console.log(res);
      alert('Employee Deleted Successfully');
      this.getAllEmployee();
    }, err=>{
      console.log(err);
    });
  }
}

