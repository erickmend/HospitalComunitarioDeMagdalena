using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ApplicationUser
{
    public class LoginPost
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public bool IsClient { get; set; }
    }
}
