import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../_interfaces/Employee';
import { Products } from '../_interfaces/Products';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly baseUrl = "https://localhost:5001/api/employee";
  readonly baseUrl2 = "https://localhost:5001/api/product";

  constructor(private http : HttpClient) { }


  getAllEmployee()
  {
    return this.http.get<Employee[]>(this.baseUrl+"/GetAllEmployee");
  }

  addEmployee(employee:Employee)
  {
    return this.http.post<Employee[]>(this.baseUrl+"/Add",employee);
  }

  getAllProduct()
  {
    return this.http.get<Products[]>(this.baseUrl2);
  }
}
