using System;
using System.Collections.Generic;

namespace RepositoryLayer.Entity
{
    public partial class PhoneBook
    {
        public int ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? PostCode { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
