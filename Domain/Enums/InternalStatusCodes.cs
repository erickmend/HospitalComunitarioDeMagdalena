using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum InternalStatusCodes
    {
        [Description("Could not save data_No se pudo guardar los datos")]
        CreateEntity_ERROR = 600,
        [Description("Could not delete data_No se pudo eliminar los datos")]
        DeleteEntity_ERROR = 601,
        [Description("Could not get data_No se pudo obtener los datos")]
        GetEntity_ERROR = 602,
        [Description("Could not get data_No se pudo obtener los datos")]
        GetList_ERROR = 603,
        [Description("Could not update data_No se pudo actualizar los datos")]
        UpdateEntity_ERROR = 604,
        [Description("There was an unknown error_Hubo un error desconocido")]
        Unknown_ERROR = 605,

        
        [Description("Data saved_Datos guardados")]
        CreateEntity_Ok = 700,
        [Description("Deleted data_Datos eliminados")]
        DeleteEntity_Ok = 701,
        [Description("Data obtained_Datos obtenidos")]
        GetEntity_Ok = 702,
        [Description("Data obtained_Datos obtenidos")]
        GetList_Ok = 703,
        [Description("Updated data_Datos actualizados")]
        UpdateEntity_Ok = 704,
    }
}
