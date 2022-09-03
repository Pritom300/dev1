import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EmployeeService } from '../services/employee.service';
import { ProductService } from '../services/product.service';

import { Products } from '../_interfaces/Products';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  
  product : Products[];

  sproduct : Products;

  constructor(private service: ProductService, private router:Router) { }

  ngOnInit(): void {
    this.service.getAllProduct().subscribe(data=>{
      this.product=data;
      console.log(data);
  })

}

getProduct(id:number)
{

  this.router.navigate(["/details/"+id]);

}

editProduct(id:number)
{
  this.router.navigate(["/update/"+id]);

}

deleteProduct(id:number)
{

  this.router.navigate(["/delete/"+id]);

}




}



