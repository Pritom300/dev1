using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController: ControllerBase
    {
        private readonly IProductRepository _repo;
        private readonly DataContext _context;
        public ProductController(IProductRepository repo, DataContext context)
        {
            _repo = repo;
            _context = context;
        }


        [HttpGet]
        public async Task< ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
           
            
            var product = await _repo.GetProductsAsync(); 

            return product.Select(product => new ProductToReturnDto{ 

                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                WarehouseList = product.WarehouseList.WarehouseList,
                
            }).ToList();                          
        }






        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            
            var product =  await _repo.GetProductByIdAsync(id);   

            return new ProductToReturnDto
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                WarehouseList = product.WarehouseList.WarehouseList,
               
            };
        }


        [HttpPut("UpdateBook/{id}")]
        public IActionResult Update(int id, [FromBody]Products newProduct)
        {
           
             var p = _repo.update(id,newProduct);
             if(p==null)
             {
                return BadRequest();
             }

             return Ok();
            
        }

        [HttpPost("AddBook")]
        public IActionResult Add(Products product)
         {
             var r = _repo.AddProduct(product);
             return Ok();

         }


           [HttpGet("war")]
           public async Task< ActionResult<List<Warehouse>>> GetWar()
           {
               return  _context.Warehouse.ToList();

           } 


    [HttpDelete("{id:int}")]
     public async Task<ActionResult<Employee>> deleteProduct(int id)
     {
         var r = _repo.delete(id);
         if(r==null)
         {
             return NotFound();
         }

         return Ok();

     }




        
    }
}