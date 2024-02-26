
namespace CRM.API.Properties.Models.EN
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        public static implicit operator Customer(List<Customer> v)
        {
            throw new NotImplementedException();
        }
    }
}
