import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from '../services/product.service';
import { Warehouse } from '../_interfaces/Warehouse';

@Component({
  selector: 'app-productadd',
  templateUrl: './productadd.component.html',
  styleUrls: ['./productadd.component.scss']
})
export class ProductaddComponent implements OnInit {

  addProductForm:FormGroup;
  war:Warehouse[];
 
  constructor(private service : ProductService, private fb : FormBuilder,private router:Router) { }

  ngOnInit(): void {
    this.addProductForm = this.fb.group({
      id:[Math.floor(Math.random()*100)],
      name:[null],
      image:[null],
      warehouseId:[null]
    });

    this.service.getAllWar().subscribe(data=>{
      console.log(data);
      this.war=data;
    })
  }

  onSubmit(addProductForm)
  {
    this.service.addProduct(this.addProductForm.value).subscribe(data=>{
      console.log("hellow world");
      this.router.navigate(["/product"])
    })
  }

}
