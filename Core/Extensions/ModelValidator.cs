using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ModelValidator
    {
        public static bool ValidateModel(this object model)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(model, validationContext, validationResults, true);
        }
    }
}
