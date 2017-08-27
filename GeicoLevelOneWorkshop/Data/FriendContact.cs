using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Data
{
    public class FriendContact : Contact
    {
        public FriendContact(string taxID) : base(taxID)
        {
        }

        private string _Email;

        public string Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }
        public string Employer { get; set; }
        public DateTime? Birthday { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Employer),
                    this.Employer) +
               String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Birthday),
                    ((this.Birthday != null)?this.Birthday.Value.ToString(Constants.Defaults.DateFormat):String.Empty)) +
                this.PrintCreatedModifiedDate();
        }
    }
}
