import { Warehouse } from "./Warehouse";

export interface ProductHandle {
    id : number;
    name : string;
    image : string;
    warehouseId? : number;
    warehouseList? : Warehouse;
  }


  

  