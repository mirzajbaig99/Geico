using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Data
{
    abstract public class Contact
    {
        public Contact(string taxID)
        {
            this.TaxID = taxID;
            this.CreatedDate = DateTime.Now;
            this.ModifiedDate = DateTime.Now;
        }
        
        public string TaxID { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.TaxID,
                    this.TaxID) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(this.Name),
                   this.Name) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(this.Address),
                   (this.Address != null) ? this.Address : String.Empty) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.PhoneNumber,
                   (this.PhoneNumber != null) ? this.PhoneNumber : String.Empty);
        }

        public string PrintCreatedModifiedDate()
        {
            return String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.ModifiedDate,
                    this.ModifiedDate.ToString(Constants.Defaults.DateFormat)) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.CreatedDate,
                    this.CreatedDate.ToString(Constants.Defaults.DateFormat));
        }
    }
}
