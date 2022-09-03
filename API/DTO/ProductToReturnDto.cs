using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.DTO
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }   

        public string Image { get; set; }

        public string Name { get; set; }
        public string WarehouseList { get; set; }

    }
}