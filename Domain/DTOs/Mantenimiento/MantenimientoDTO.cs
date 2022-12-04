using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Mantenimiento
{
    public class MantenimientoDTO
    {
        public DateTime FechaDeMtto { get; set; }
        public string TipoDeMtto { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;
    }
}
