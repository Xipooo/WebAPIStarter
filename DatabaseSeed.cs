using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIStarterData;
using WebAPIStarterData.Models;

namespace WebAPIStarter
{
    public class DatabaseSeed
    {
        private IApplicationBuilder _app;

        public DatabaseSeed(IApplicationBuilder app)
        {
            _app = app;
        }
        public void Initialize()
        {
            using (var serviceScope = _app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<WebAPIStarterContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.AddressTypes.Any())
                {
                    context.AddressTypes.AddRange(new List<AddressType> {
                    new AddressType
                        {
                            Id = 1,
                            AddressTypeName = "Home"
                        },
                    new AddressType
                    {
                        Id = 2,
                        AddressTypeName = "Work"
                    },
                    new AddressType
                    {
                        Id = 3,
                        AddressTypeName = "Bill To"
                    },
                    new AddressType
                    {
                        Id = 4,
                        AddressTypeName = "Ship To"
                    }});
                }

                if (!context.Addresses.Any())
                {
                    context.Addresses.AddRange(
                        new Address
                        {
                            Id = 1,
                            Line1 = "123 Fake St.",
                            City = "Fakeville",
                            StateProvince = "Fakington",
                            Zipcode = "00001",
                            AddressTypeId = 1
                        },
                            new Address
                            {
                                Id = 2,
                                Line1 = "456 Double Ave.",
                                City = "Doubleton",
                                StateProvince = "Doublisconsin",
                                Zipcode = "11111",
                                AddressTypeId = 2
                            }
                    );
                }

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(
                        new Customer
                        {
                            Id = 1,
                            FirstName = "Steve",
                            LastName = "Bishop",
                            Email = "steve.bishop@galvanize.com",
                            CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 1, AddressId = 2 }
                                }
                        },
                            new Customer
                            {
                                Id = 2,
                                FirstName = "Paul",
                                LastName = "Goldschmidt",
                                Email = "paul@cardinals.com",
                                CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 2, AddressId = 2 }
                                }
                            },
                            new Customer
                            {
                                Id = 3,
                                FirstName = "Bilbo",
                                LastName = "Baggins",
                                Email = "BilboB@theshire.net",
                                CustomerAddresses = new List<CustomerAddress> {
                                    new CustomerAddress{ CustomerId = 3, AddressId = 1 }
                                }
                            }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}