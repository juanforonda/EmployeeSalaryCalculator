import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { IEmployee } from './employee';
import { from } from 'rxjs';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  pageTitle:string = 'Salary Calculator';
  employees: IEmployee[] = [];
  employeeIdToSearch: number;
  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }
  getEmployees() {
    
    if (this.employeeIdToSearch) {
      this.getEmployee();
    }else{
      this.employeeService.getEmployees().subscribe(emp => {
        this.employees = emp;
      });
    }
    
  }
  getEmployee() {
    this.employees = [];
    this.employeeService.getEmployeeById(this.employeeIdToSearch).subscribe(emp =>{
      this.employees.push(emp);
    });
  }

}
