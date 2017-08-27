using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Data
{
    public enum eTitle { NONE, MR, MRS, MISS, DR}
    public class WorkContact : Contact
    {
        public WorkContact(string taxID) : base(taxID)
        {
        }

        private string _Email;

        public string Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }
        public eTitle Title { get; set; }
        public string Employer {get; set;}
        public string Url { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Url),
                    this.Url) +
                 String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Employer),
                    this.Employer) +
                 String.Format(Constants.Defaults.DefaultPrintFormat, nameof(Title),
                    this.Title) +
                this.PrintCreatedModifiedDate();
        }
    }
}
