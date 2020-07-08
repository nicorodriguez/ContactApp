using ContactApp.Context;
using ContactApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Repository.ContactRepository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationContext context) : base(context) { }

        public override async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contact
                                .Include(x => x.Profile)
                                .ToListAsync();
        }

        public override async Task<Contact> GetById(int id)
        {
            return await _context.Contact
                                .Where(c => c.ContactId == id)
                                .Include(x => x.Profile)
                                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Contact>> GetByEmailOrPhoneNumber(string search)
        {
            return await _context.Contact
                                .Where(c => c.Email.StartsWith(search) || c.PersonalNumber.StartsWith(search) || c.WorkNumber.StartsWith(search))
                                .Include(x => x.Profile)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetByCity(string search)
        {
            return await _context.Contact
                                .Where(c => c.City == search)
                                .Include(x => x.Profile)
                                .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetByState(string search)
        {
            return await _context.Contact
                                .Where(c => c.State == search)
                                .Include(x => x.Profile)
                                .ToListAsync();
        }
    }
}
