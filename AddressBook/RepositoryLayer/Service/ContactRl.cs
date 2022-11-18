using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReprositoryLayer.Service
{
    public class ContactRl : IContactRl
    {
        private readonly Address_Book_ServiceContext contactContext;

        public ContactRl(Address_Book_ServiceContext contactContext)
        {
            this.contactContext = contactContext;
        }
        public PhoneBook AddContact(PhoneBook contactModel)
        {
            try
            {
                PhoneBook addressBookTable = new PhoneBook();
                addressBookTable.FullName = contactModel.FullName;
                addressBookTable.Email = contactModel.Email;
                addressBookTable.City = contactModel.City;
                addressBookTable.State = contactModel.State;
                addressBookTable.PostCode = contactModel.PostCode;
                addressBookTable.PhoneNumber = contactModel.PhoneNumber;

                contactContext.PhoneBook.Add(addressBookTable);
                var result = contactContext.SaveChanges();

                if (result != 0)
                {
                    return addressBookTable;
                }
                else
                {
                    return null;
                }
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
                var view = contactContext.PhoneBook.Where(x => x.ContactId == ContactId).FirstOrDefault();
                if (view != null)
                {
                    return contactContext.PhoneBook.Where(list => list.ContactId == ContactId).ToList();
                }
                else
                {
                    return null;
                }
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
                var update = contactContext.PhoneBook.Where(x => x.ContactId == ContactId).FirstOrDefault();
                if (update != null)
                {
                    update.FullName = contactModel.FullName;
                    update.Email = contactModel.Email;
                    update.City = contactModel.City;
                    update.State = contactModel.State;
                    update.PostCode = contactModel.PostCode;
                    update.PhoneNumber = contactModel.PhoneNumber;
                    contactContext.PhoneBook.Update(update);
                    contactContext.SaveChanges();
                    return update;
                }
                else
                {
                    return null;
                }
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
                var delete = contactContext.PhoneBook.Where(x => x.ContactId == ContactId).FirstOrDefault();
                if (delete != null)
                {
                    contactContext.PhoneBook.Remove(delete);
                    contactContext.SaveChanges();
                    return delete;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}