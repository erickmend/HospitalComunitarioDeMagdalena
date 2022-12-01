using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public  static class InternarlStatusCodesExtensions
    {
        public static string[] GetDescription(this InternalStatusCodes val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            string[] errorOutput = new string[2];
            return attributes.Length > 0 ? attributes[0].Description.Split('_') : errorOutput;
        }
        public static int GetInt(this InternalStatusCodes val)
        {
            return (int)val;
        }
    }
}
