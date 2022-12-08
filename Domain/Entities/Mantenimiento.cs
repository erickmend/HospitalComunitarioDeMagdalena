using Domain.DTOs.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mantenimiento : Entity
    {
        public Mantenimiento()
        {
            
        }
        public Mantenimiento(MantenimientoDTO dto)
        {
            FechaDeMtto = dto.FechaDeMtto;
            TipoDeMtto = dto.TipoDeMtto;
            Observaciones = dto.Observaciones;
            Responsable = dto.Responsable;
            CreateEntity();
        }
        public DateTime FechaDeMtto { get; set; }
        public string TipoDeMtto { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public string Responsable { get; set; } = string.Empty;

        public void Edit(MantenimientoDTO dto)
        {
            FechaDeMtto = dto.FechaDeMtto;
            TipoDeMtto = dto.TipoDeMtto;
            Observaciones = dto.Observaciones;
            Responsable = dto.Responsable;
            EditEntity();
        }
        public int EquipoMedicoId { get; set; }
        public virtual EquipoMedico EquipoMedico { get; set; }
    }
}
