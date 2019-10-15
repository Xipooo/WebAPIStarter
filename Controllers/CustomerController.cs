using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIStarter.Models;
using WebAPIStarter.Services.CustomerService;

namespace WebAPIStarter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomerController(ICustomerService customerService = null)
        {
            this.customerService = customerService ?? new InMemoryCustomerService();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne([FromRoute] long id)
        {
            var result = this.customerService.GetOne(id);
            if (result != null) return Ok(result);
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this.customerService.GetAll());
        }

        [HttpPost("[action]")]
        public IActionResult Create([FromBody] Customer newCustomer)
        {
            if (ModelState.IsValid)
            {
                newCustomer = customerService.Add(newCustomer);
                return CreatedAtAction("GetOne", new { newCustomer.Id }, newCustomer);
            }
            return base.ValidationProblem();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult Update([FromBody] Customer updatedCustomer)
        {
            customerService.Update(updatedCustomer);
            if (customerService.GetOne(updatedCustomer.Id) != null){
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            Customer deletedCustomer = customerService.GetOne(id);
            if (deletedCustomer == null){
                return NotFound();
            }
            customerService.Delete(deletedCustomer);
            return NoContent();
        }
    }
}