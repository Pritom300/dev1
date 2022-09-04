using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository (DataContext context)
        {
            _context = context;
        }

        public async Task<Products> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p=>p.WarehouseList)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<Products>> GetProductsAsync()
        {
           return await _context.Products
            .Include(p=>p.WarehouseList)
            .ToListAsync();
        }

        public Products update(int id, Products newProducts)
        {
            var old = _context.Products.FirstOrDefault(p=>p.Id==id);
            //var w = _context.Warehouse.FirstOrDefault(p=>p.Id==newProducts.WarehouseId);

            if(old!=null)
            { 
                old.Name=newProducts.Name;
                old.Image=newProducts.Image;
                old.WarehouseId= newProducts.WarehouseId;
                _context.SaveChanges();
                return old;

            }
            return null;
        }

        public Products AddProduct(Products newProduct)
        {
            
            newProduct.Id=0;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;

        }

        public Products delete(int id)
        {
            var old = _context.Products.FirstOrDefault(p=>p.Id==id);
            if(old!=null)
            {
                _context.Products.Remove(old);
                _context.SaveChanges();
                return old;
            }

            return null;

        }
    }
}