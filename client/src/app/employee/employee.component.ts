import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Employee } from '../_interfaces/Employee';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit {

  public employee : Employee[];

  constructor(private service : EmployeeService) { }

  ngOnInit(): void {
    this.service.getAllEmployee().subscribe(data=>{
      this.employee=data;
    })
  }



}
