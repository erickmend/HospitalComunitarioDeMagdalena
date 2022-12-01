using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class JsonObjectToDto<T>
    {
        public static T GetDTO(object response)
        {
            string json = JsonConvert.SerializeObject(response);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
