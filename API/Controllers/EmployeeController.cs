using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Models;
using API.Data;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
           _context = context;
        }


        [HttpGet("GetAllEmployee"), Authorize(Roles = "Student")]
        public List<Employee> GetAllEmployee()
        {
            var allEmp = _context.Employee.ToList();
            return allEmp;
        }

        [HttpPost("Add")]
        public void Add(Employee em)
        {
             em.Id=0;
            _context.Employee.Add(em);
            _context.SaveChanges();
        }


        
        [HttpGet("UpdateEmployee")]
        public void Update(int Id,Employee em)
        {
            var oE = _context.Employee.FirstOrDefault(n=> n.Id==Id);

            if(oE!=null)
            {

                oE.firstName=em.firstName;
                oE.lastName = em.lastName;
                oE.description = em.description;
                oE.status = em.status;
            }

            _context.SaveChanges();
        }



        [HttpPost("Delete")]
         public void RemoveEmployee(int Id, Employee em)
        {
            var re = _context.Employee.FirstOrDefault(n=> n.Id==Id);

            if(re!=null)
            {
                _context.Employee.Remove(re);
                _context.SaveChanges();
            }

            else
            {
                NotFound();
            }
        }


    }
}