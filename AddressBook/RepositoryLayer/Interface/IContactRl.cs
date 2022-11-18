using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IContactRl
    {
        public PhoneBook AddContact(PhoneBook contactModel);
        public List<PhoneBook> ViewContact(long ContactId);
        public PhoneBook UpdateContact(PhoneBook contactModel, long ContactId);
        public PhoneBook DeleteContact(long ContactId);
    }
}
