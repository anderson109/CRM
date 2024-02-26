using System.ComponentModel.DataAnnotations;
namespace CRM.DTOs.CustomerDTOs
{
    public class EditCustomerDTO
    {
        public EditCustomerDTO(GetIdResultCustomerDTO getIdResultCustomerDTO)
        {
            Id = getIdResultCustomerDTO.Id;
            Name = getIdResultCustomerDTO.Name;
            LastName = getIdResultCustomerDTO.LastName;
            Address = getIdResultCustomerDTO.Address;

        }

        public EditCustomerDTO() 
        {
        Name = string.Empty;
        LastName = string.Empty;
        }
        [Required(ErrorMessage = "El campo Id es Obligatorio")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres.")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres.")]
        public string LastName { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(255, ErrorMessage = "El campo Nombre no puede tener mas de 50 caracteres.")]
        public string? Address { get; set; }
    }
}