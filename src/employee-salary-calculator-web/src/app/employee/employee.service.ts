import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {IEmployee} from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private employeeServiceBaseAddress = 'https://localhost:44346/api/';
  constructor(private httpClient: HttpClient) {  }

  getEmployees(): Observable<IEmployee[]>{
    return this.httpClient.get<IEmployee[]>(`${this.employeeServiceBaseAddress}employees`);
  }

  getEmployeeById(id:number): Observable<IEmployee>{
    return this.httpClient.get<IEmployee>(`${this.employeeServiceBaseAddress}employees/${id}`);
  }
}
