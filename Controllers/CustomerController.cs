using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private List<Customer> customers; 

        public CustomerController()
        {
            this.customers = new List<Customer> {
             new Customer { Id = 1, FirstName = "Steve", LastName = "Bishop", Email = "steve.bishop@galvanize.com" },
             new Customer { Id = 2, FirstName = "Marla", LastName = "Gonzales", Email = "mGone@home.net" },
             new Customer { Id = 3, FirstName = "Alfred", LastName = "Pennyworth", Email = "alfred@thebatcave.org" }
         };
        }

        [HttpGet("api/Customer/{id}")]
        public Customer GetOne(int id) {
            foreach (Customer customer in this.customers){
                if (customer.Id == id) {
                    return customer;
                }
            }
            return null;
        }

        [HttpGet("api/Customer")]
        public List<Customer> GetAll() {
            return this.customers;
        }

        [HttpPost("api/Customer")]
        public string Create() {
            Customer newCustomer = new Customer {
                Id = this.customers.Count + 1,
                FirstName = "John",
                LastName = "Sonmez",
                Email = "IDontHaveIt@bigdog.com"
            };
            this.customers.Add(newCustomer);
            return "Created";
        }

        [HttpPut("api/Customer")]
        public string Update() {
            foreach (Customer customer in customers) {
                if (customer.Id == 1) {
                    customer.FirstName = "Steven";
                }
            }
            return "Updated";
        }

        [HttpDelete("api/Customer")]
        public string Delete() {
            foreach (Customer customer in customers) {
                if (customer.Id == 1) {
                    customers.Remove(customer);
                }
            }
            return "Deleted";
        }
    }
}