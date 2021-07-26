using Contact_List_Core.Entities;
using Contact_List_Data_Access_Layer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_List_Data_Access_Layer.Repository
{
    public class ContactRepository : IContact
    {
        private readonly DBContext dbContext;

        public ContactRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
    

        public async Task<IEnumerable<Contact>> GetContactList()
        {
            return await dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContact(int contactId)
        {
            return await dbContext.Contacts
               .FirstOrDefaultAsync(e => e.ContactId == contactId);
        }

        public async Task<Contact> AddContact(Contact contact)
        {
           var result = await dbContext.Contacts.AddAsync(contact);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }



        public async Task DeleteContact(int contactId)
        {
            var result = await dbContext.Contacts
                .FirstOrDefaultAsync(e => e.ContactId == contactId);

            if (result != null)
            {
                dbContext.Contacts.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Contact> UpdateContact(Contact contact)
        {
            var result = await dbContext.Contacts
                .FirstOrDefaultAsync(e => e.ContactId == contact.ContactId);

            if (result != null)
            {
                result.ContactFirstName = contact.ContactFirstName;
                result.ContactLastName = contact.ContactLastName;
                result.ContactEmailAddress = contact.ContactEmailAddress;
                result.ContactPhoneNumber = contact.ContactPhoneNumber;
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
