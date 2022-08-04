import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.scss']
})
export class NewEmployeeComponent implements OnInit {


  addEmployeeForm : FormGroup;
  constructor(private service:EmployeeService,private fb:FormBuilder,private router:Router) { }

  ngOnInit(): void {

    this.addEmployeeForm = this.fb.group({
      Id:0,
      firstName:[null],
      lastName:[null],
      description:[null],
      status:[null]
    })
  }

  onSubmit()
  {
    this.service.addEmployee(this.addEmployeeForm.value).subscribe(data=>{
    this.router.navigate(["/employee"]);
    })
  }

}
