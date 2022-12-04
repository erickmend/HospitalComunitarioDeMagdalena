using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.EquipoMedico
{
    public class EquipoMedicoDTO
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string NumDeIdentificacion { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreDelEquipo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string NombreDelCuadroBasico { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string ClaveDelCuadroBasico { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string Fabricante { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string Modelo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string NumeroDeSerie { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string UbicacionDelEquipo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string EstatusOperativo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime FechaInicialDeRegistro { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string InclusionDeMantenimiento { get; set; } = string.Empty;
        [Required(ErrorMessage = "El campo es requerido")]
        public string PropioOComodato { get; set; } = string.Empty;
    }
}
