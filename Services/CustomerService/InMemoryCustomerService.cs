using System.Collections.Generic;
using WebAPIStarterData.Models;

namespace WebAPIStarter.Services.CustomerService
{
    public class InMemoryCustomerService : ICustomerService
    {
        private IList<Customer> customers;

        public InMemoryCustomerService(IList<Customer> customer = null)
        {
            this.customers = customers ?? new List<Customer>();
        }
        public Customer Add(Customer newCustomer)
        {
            newCustomer.Id = customers.Count + 1;
            this.customers.Add(newCustomer);
            return newCustomer;
        }

        public void Delete(Customer deletedCustomer)
        {
            foreach (Customer customer in customers){
                if (customer.Id == deletedCustomer.Id) {
                    customers.Remove(customer);
                    return;
                }
            }
            return;
        }

        public IList<Customer> GetAll()
        {
            return this.customers;
        }

        public Customer GetOne(long id)
        {
            foreach (Customer customer in customers){
                if (customer.Id == id) {
                    return customer;
                }
            }
            return null;
        }

        public void Update(Customer updatedCustomer)
        {
            foreach (Customer customer in customers){
                if (customer.Id == updatedCustomer.Id) {
                    customer.FirstName = updatedCustomer.FirstName;
                    customer.LastName = updatedCustomer.LastName;
                    customer.Email = updatedCustomer.Email;
                    return;
                }
            }
        }
    }
}