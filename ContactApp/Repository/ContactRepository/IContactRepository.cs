using ContactApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Repository.ContactRepository
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Task<IEnumerable<Contact>> GetByEmailOrPhoneNumber(string search);
        Task<IEnumerable<Contact>> GetByCity(string search);
        Task<IEnumerable<Contact>> GetByState(string search);
    }
}
