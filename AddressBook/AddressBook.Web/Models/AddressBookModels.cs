using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AddressBook.Web.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Changed { get; set; }
    }
}