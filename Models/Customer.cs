using System.ComponentModel.DataAnnotations;
namespace WebAPIStarter.Models
{
    public class Customer
    {
        public long Id { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}