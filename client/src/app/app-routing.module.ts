import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomersComponent } from './customers/customers.component';
import { EmployeeComponent } from './employee/employee.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { NewEmployeeComponent } from './new-employee/new-employee.component';
import { ProductaddComponent } from './productadd/productadd.component';
import { ProductdeleteComponent } from './productdelete/productdelete.component';
import { ProductdetailsComponent } from './productdetails/productdetails.component';
import { ProductsComponent } from './products/products.component';
import { ProductupdateComponent } from './productupdate/productupdate.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'delete/:id', component: ProductdeleteComponent, canActivate: [AuthGuard] },
  { path: 'update/:id', component: ProductupdateComponent, canActivate: [AuthGuard] },
  { path: 'add', component: ProductaddComponent, canActivate: [AuthGuard] },
  { path: 'details/:id', component: ProductdetailsComponent, canActivate: [AuthGuard]},
  { path: 'product', component: ProductsComponent, canActivate: [AuthGuard]},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'employee', component: EmployeeComponent, canActivate: [AuthGuard] },
  { path: 'newemployee', component: NewEmployeeComponent, canActivate: [AuthGuard] },
  { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
