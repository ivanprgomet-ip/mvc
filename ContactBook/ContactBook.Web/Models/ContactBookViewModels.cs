using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Web.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Changed { get; set; }

        public ContactViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
    public class ContactEditViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public ContactEditViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
    public class ContactListedViewModel
    {

    }
    public class ContactDetailsViewModel
    {

    }
}
