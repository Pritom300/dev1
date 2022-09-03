using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }
       //relationship
        public int WarehouseId { get; set; }
        public Warehouse WarehouseList { get; set; }



    }
}