using Domain.DTOs.EquipoMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EquipoMedico :Entity
    {
        public EquipoMedico()
        {
            
        }
        public EquipoMedico(EquipoMedicoDTO dto)
        {
            NumDeIdentificacion = dto.NumDeIdentificacion;
            NombreDelEquipo = dto.NombreDelEquipo;
            NombreDelCuadroBasico = dto.NombreDelCuadroBasico;
            ClaveDelCuadroBasico = dto.ClaveDelCuadroBasico;
            Fabricante = dto.Fabricante;
            Modelo = dto.Modelo;
            NumeroDeSerie = dto.NumeroDeSerie;
            UbicacionDelEquipo = dto.UbicacionDelEquipo;
            EstatusOperativo = dto.EstatusOperativo;
            FechaInicialDeRegistro = dto.FechaInicialDeRegistro;
            InclusionDeMantenimiento = dto.InclusionDeMantenimiento;
            PropioOComodato = dto.PropioOComodato;

            Mantenimientos = new List<Mantenimiento>();

            CreateEntity();
        }
        
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
        public string  InclusionDeMantenimiento { get; set; } = string.Empty;
        public string PropioOComodato { get; set; } = string.Empty;


        public List<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
        
        public void Edit(EquipoMedicoDTO dto)
        {
            NumDeIdentificacion = dto.NumDeIdentificacion;
            NombreDelEquipo = dto.NombreDelEquipo;
            NombreDelCuadroBasico = dto.NombreDelCuadroBasico;
            ClaveDelCuadroBasico = dto.ClaveDelCuadroBasico;
            Fabricante = dto.Fabricante;
            Modelo = dto.Modelo;
            NumeroDeSerie = dto.NumeroDeSerie;
            UbicacionDelEquipo = dto.UbicacionDelEquipo;
            EstatusOperativo = dto.EstatusOperativo;
            FechaInicialDeRegistro = dto.FechaInicialDeRegistro;
            InclusionDeMantenimiento = dto.InclusionDeMantenimiento;
            PropioOComodato = dto.PropioOComodato;

            EditEntity();
        }
    }
}
