import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../_interfaces/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly baseUrl = "https://localhost:5001/api/employee";

  constructor(private http : HttpClient) { }


  getAllEmployee()
  {
    return this.http.get<Employee[]>(this.baseUrl+"/GetAllEmployee");
  }

  addEmployee(employee:Employee)
  {
    return this.http.post<Employee[]>(this.baseUrl+"/Add",employee);
  }
}
