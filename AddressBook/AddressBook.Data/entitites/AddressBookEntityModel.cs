using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.entitites
{
    class AddressBookEntityModel
    {
        public List<ContactEntityModel> Contacts { get; set; }
        public AddressBookEntityModel()
        {
            Contacts = new List<ContactEntityModel>();
        }
    }
}
