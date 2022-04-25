using ContactList.Models;

namespace ContactList.Services
{
    public interface IContacts
    {
        List<Contacts> GetAll();
        void Save();
        void Insert(Models.Contacts contacts);
        void Delete(int id);
        void Update(Models.Contacts contacts);  

        Contacts getByID(int id);
    }
}
