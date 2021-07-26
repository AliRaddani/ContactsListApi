using Contact_List_Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;


namespace Contact_List_Data_Access_Layer.Mapping
{
    class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            this.Map(m =>
            {
                m.ToTable("Contacts");
                m.Requires("LOGL_DEL_IND").HasValue(false);
            });

            this.HasKey(p => p.ContactId);
            this.Property(p => p.ContactId).HasColumnName("ContactId");
            this.Property(p => p.ContactFirstName).HasColumnName("ContactFirstName");
            this.Property(p => p.ContactLastName).HasColumnName("ContactLastName");
            this.Property(p => p.ContactPhoneNumber).HasColumnName("ContactPhoneNumber");
            this.Property(p => p.ContactEmailAddress).HasColumnName("ContactEmailAddress");
        }
    }
}
