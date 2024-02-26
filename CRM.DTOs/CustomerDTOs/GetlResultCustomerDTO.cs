using System.ComponentModel.DataAnnotations;

namespace CRM.DTOs.CustomerDTOs
{
  public class GetIdResultCustomerDTO
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
