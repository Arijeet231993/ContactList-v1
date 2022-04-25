using ContactList.Models;
using ContactList.Data;

namespace ContactList.Services
{
    public class ContactRepository : IContacts
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            Contacts cat = getByID(id); 
            if (cat != null)
            {
                _context.Remove(cat);
            }
           // throw new NotImplementedException();
        }
        public List<Contacts> GetAll()
        {
            return _context.contacts.ToList();
            // throw new NotImplementedException();
        }

        public Contacts getByID(int id)
        {
            return _context.contacts.Where(a => a.Id == id).SingleOrDefault();
            //throw new NotImplementedException();
        }

        public void Insert(Contacts contacts)
        {
            _context.Add(contacts);
            //throw new NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
           // throw new NotImplementedException();
        }

        public void Update(Contacts contacts)
        {
            _context.contacts.Update(contacts);
            //throw new NotImplementedException();
        }

        
    }
}