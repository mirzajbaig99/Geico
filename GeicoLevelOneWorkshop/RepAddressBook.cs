using GeicoLevelOneWorkshop.Data;
using GeicoLevelOneWorkshop.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop
{
    public enum eAddressType { Company, Work, Friend };
    public class RepAddressBook : IRepAddressBook
    {
        private List<Contact> addressBook;

        public RepAddressBook()
        {
            this.addressBook = new List<Contact>();
        }
        
        public void IsExists(string taxId)
        {
            if(this.SearchByTaxID(taxId) != null)
            {
                throw new TaxIdUniqueException();
            }
        }
        public void Add(Contact contact)
        {
            addressBook.Add(contact);
        }

        public Contact SearchByTaxID(string taxId)
        {
            return this.addressBook.Where(w => w.TaxID == taxId).FirstOrDefault();
        }

        public List<Contact> SearchByName(string Name)
        {
            return this.addressBook.Where(w => w.Name == Name).ToList();
        }

        public void DeleteContact(string taxId)
        {
            Contact retval = this.SearchByTaxID(taxId);
            if(retval != null)
            {
                this.addressBook.Remove(retval);
            }else
            {
                throw new ExceptionContactNotFound();
            }
        }
    }
}
