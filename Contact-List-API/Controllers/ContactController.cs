using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_List_Core.Entities;
using Contact_List_Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contact_List_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ValuesController>
        private readonly IContact contactRepo;

        public ContactController(IContact contactRepo)
        {
            this.contactRepo = contactRepo;
        }

        // GET: api/<ContactController>
        [HttpGet("/GetContactList")]
        public Task<IEnumerable<Contact>> GetContactsList()
        {
            return contactRepo.GetContactList();
        }

        [HttpPost("AddContact")]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            try
            {
                if (contact == null)
                    return BadRequest();
                var createdContact = await contactRepo.AddContact(contact);

                return createdContact;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpPut("/UpdateContact{id:int}")]
        public async Task<ActionResult<Contact>> UpdateContact(int id, Contact contact)
        {
            try
            {
                if (id != contact.ContactId)
                    return BadRequest("Contact ID mismatch");

                var contactToUpdate = await contactRepo.GetContact(id);

                if (contactToUpdate == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await contactRepo.UpdateContact(contact);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating employee record");
            }
        }

        [HttpDelete("/DeleteContact{id:int}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            try
            {
                var contactToDelete = await contactRepo.GetContact(id);

                if (contactToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                await contactRepo.DeleteContact(id);

                return Ok($"Employee with Id = {id} deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting employee record");
            }
        }

    }
}