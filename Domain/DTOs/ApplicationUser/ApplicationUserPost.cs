using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ApplicationUser
{
    public class ApplicationUserPost
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El campo es requerido")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime Birthdate { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "El campo es requerido")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El campo es requerido")]
        public string Password { get; set; } = string.Empty;
    }
}
