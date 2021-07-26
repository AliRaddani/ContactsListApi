using System;
using System.Collections.Generic;
using System.Text;

namespace Contact_List_Core.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }
    }
}

