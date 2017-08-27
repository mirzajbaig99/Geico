using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Exceptions
{
    public class TaxIdUniqueException : Exception
    {
        public TaxIdUniqueException():base(Constants.Messages.taxIDAlreadyExsists)
        {

        }
    }
}
