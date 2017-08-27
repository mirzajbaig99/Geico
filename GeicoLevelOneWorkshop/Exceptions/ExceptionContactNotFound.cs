using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop.Exceptions
{
    class ExceptionContactNotFound:Exception
    {
        public ExceptionContactNotFound():base(Constants.Messages.ContactNotFound)
        {

        }
    }
}
