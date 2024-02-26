using System.ComponentModel.DataAnnotations;
namespace CRM.DTOs.CustomerDTOs
{
    public class CreateCustomerDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "el campo nombre no puede tener mas de 50 caracteres")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo apellido no puede tener mas de 50 caracteres")]
        public string LastName { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(255, ErrorMessage = "El campo de direccion no puede tener mas de 255 caracteres.")]
        public string? Address { get; set; }
    }
}
