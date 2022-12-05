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
            Path = dto.Path;
            CreateEntity();
        }
        public string Path { get; set; }
    }
}
