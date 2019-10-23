using System;
using System.Linq;
using WebAPIStarterData;
using WebAPIStarterData.Models;

namespace WebAPIStarter.Services.AddressService
{

    public class InMemoryDatabaseAddressService : IAddressService
    {
        private WebAPIStarterContext _context;

        public InMemoryDatabaseAddressService(WebAPIStarterContext context)
        {
            _context = context;
        }

        public void Add(Address newAddress)
        {
            if (String.IsNullOrEmpty(newAddress.Line1))
            {
                throw new ArgumentException("Line1 not set on address.");
            }
            if (!_context.AddressTypes.Any(at => at.Id.Equals(newAddress.AddressTypeId)))
            {
                throw new ArgumentException("Given addressTypeId not found in database.");
            }
            _context.Add(newAddress);
            _context.SaveChanges();
        }

        public Address GetOne(long addressId)
        {
            return _context.Addresses.Find(addressId);
        }

        public void Delete(long addressId)
        {
            _context.Addresses.Remove(_context.Addresses.Find(addressId));
            _context.SaveChanges();
        }
    }
}