using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Service
{
    public class ContactBl : IContactBl
    {
        private readonly IContactRl contactRl;
        public ContactBl(IContactRl contactRl)

        {
            this.contactRl = contactRl;
        }

        public PhoneBook AddContact(PhoneBook contactModel)
        {
            try
            {
                return contactRl.AddContact(contactModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<PhoneBook> ViewContact(long ContactId)
        {
            try
            {
                return contactRl.ViewContact(ContactId);
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        public PhoneBook UpdateContact(PhoneBook contactModel, long ContactId)
        {
            try
            {
                return contactRl.UpdateContact(contactModel, ContactId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PhoneBook DeleteContact(long ContactId)
        {
            try
            {
                return contactRl.DeleteContact(ContactId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}