using WebAPIStarterData.Models;

namespace WebAPIStarter.Services.AddressService
{
    public interface IAddressService
    {
        void Add(Address newAddress);
        void Delete(long addressId);
        Address GetOne(long addressId);
    }
}