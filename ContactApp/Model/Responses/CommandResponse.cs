using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Model.Responses
{
    public class CommandResponse
    {
        public bool IsSuccessful { get; set; } = false;
        public IEnumerable<string> ErrorMessages { get; set; } = new List<string>();
    }

    public class CommandResponse<T>
    {
        public bool IsSuccessful { get; set; } = false;
        public T Result { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; } = new List<string>();
    }
}
