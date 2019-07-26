import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { IEmployee } from './employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  pageTitle: string = 'Salary Calculator';
  employees: IEmployee[] = [];
  employeeIdToSearch: number;
  employeeNotFound: boolean = false;
  enableErrorMessage: boolean = false;
  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
  }
  getEmployees() {
    this.employeeNotFound = false;
    this.enableErrorMessage = false;
    if (this.employeeIdToSearch) {
      this.getEmployee();
    } else {
      this.employeeService.getEmployees().subscribe(emp => {
        this.employees = emp;
      }, error => {
        this.handleError(error);
      });
    }
  }
  getEmployee() {
    this.employees = [];
    this.employeeService.getEmployeeById(this.employeeIdToSearch).subscribe(emp => {
      this.employees.push(emp);
    }, error => {
      this.handleError(error);
    });
  }

  handleError(error){
    if (error.status === 404) {
      this.employeeNotFound = true;
    }
    else {
      this.enableErrorMessage = true
    }
  }
}
