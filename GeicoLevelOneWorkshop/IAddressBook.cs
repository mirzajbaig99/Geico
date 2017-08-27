using GeicoLevelOneWorkshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop
{
    public interface IAddressBook
    {
        void Add(Contact contact);

        Contact SearchByTaxID(string taxId);

        List<Contact> SearchByName(string Name);

        void DeleteContact(string taxId);
       
    }
}
