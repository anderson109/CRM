using System.ComponentModel.DataAnnotations;

namespace CRM.DTOs.CustomerDTOs
{
    public class SearchResultCustomerDTO
    {
        public int CountRow { get; set; }
        public List<CustomerDTO> Data { get; set; }
        public class CustomerDTO
        {
            public int Id { get; set; }

            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Display(Name = "Apellido")]
            public string LastName { get; set; }

            [Display(Name = "Direccion")]
            public string? Address { get; set; }
        }
    }
}
