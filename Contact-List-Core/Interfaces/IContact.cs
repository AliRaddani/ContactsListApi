using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contact_List_Core.Entities
{
    public interface IContact 
    {
        /// <summary>
        /// Fetches all contacts
        /// </summary>
        /// <returns>A list of Contact objects</returns>
        Task<IEnumerable<Contact>> GetContactList();

        Task<Contact> GetContact(int contactId);
        Task<Contact> AddContact(Contact contact);
        Task<Contact> UpdateContact(Contact contact);
        Task DeleteContact(int contactId);
    }
}
