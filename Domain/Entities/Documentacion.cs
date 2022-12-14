using Domain.DTOs.Documentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Documentacion :Entity
    {
        public Documentacion()
        {
            
        }
        public Documentacion(DocumentacionDTO dto)
        {
            Nombre = dto.Nombre;
            Path = dto.Path;
            Fecha = dto.Fecha;
            CreateEntity();
        }
        public void Edit(DocumentacionDTO dto)
        {
            Nombre = dto.Nombre;
            Path = dto.Path;
            Fecha = dto.Fecha;
            EditEntity();
        }
        public string Path { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
    }
}
