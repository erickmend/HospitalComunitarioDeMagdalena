using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ApplicationUser
{
    public class RecoverPasswordDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Email { get; set; } 
    }
}
