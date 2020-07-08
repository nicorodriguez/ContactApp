using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Model.Mappers
{
    public static class JsonErrorMapper
    {
        public static string MapToJSON(this ValidationFailure value, string className = null)
        {
            var propertyName =
                !String.IsNullOrEmpty(value.PropertyName) ? value.PropertyName : (className is null ? "Generic" : className);

            return JsonConvert.SerializeObject(new { PropertyName = propertyName, ErrorMessage = value.ErrorMessage });
        }
    }
}
