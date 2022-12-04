using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.EquipoMedico
{
    public class EquipoMedicoDTO
    {
        public string NumDeIdentificacion { get; set; } = string.Empty;
        public string NombreDelEquipo { get; set; } = string.Empty;
        public string NombreDelCuadroBasico { get; set; } = string.Empty;
        public string ClaveDelCuadroBasico { get; set; } = string.Empty;
        public string Fabricante { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string NumeroDeSerie { get; set; } = string.Empty;
        public string UbicacionDelEquipo { get; set; } = string.Empty;
        public string EstatusOperativo { get; set; } = string.Empty;
        public DateTime FechaInicialDeRegistro { get; set; }
        public string InclusionDeMantenimiento { get; set; } = string.Empty;
        public string PropioOComodato { get; set; } = string.Empty;
    }
}
