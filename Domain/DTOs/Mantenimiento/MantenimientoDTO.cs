using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Mantenimiento
{
    public class MantenimientoDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaDeMtto { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string TipoDeMtto { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string Observaciones { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string Responsable { get; set; } = string.Empty;
    }
}
