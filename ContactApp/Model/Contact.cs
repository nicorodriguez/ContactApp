using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Model
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string WorkNumber { get; set; }
        public string PersonalNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
