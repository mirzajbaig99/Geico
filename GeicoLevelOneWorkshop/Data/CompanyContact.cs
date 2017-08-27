using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Data
{
    public class CompanyContact : Contact
    {
        public CompanyContact(string taxID) : base(taxID)
        {
        }

        public string Url { get; set; }
        
        public override string ToString()
        {
            return base.ToString() +
                String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Url),
                    this.Url)
                + this.PrintCreatedModifiedDate();
        }
    }
}
