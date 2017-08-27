using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop
{
    public static class Validations
    {
        public static bool ValidateTaxID(string taxId)
        {
            if (String.IsNullOrWhiteSpace(taxId))
            {
                return false;
            }

            return new Regex("^\\d{1,9}$").IsMatch(taxId);
        }

        public static bool ValidateName(string name)
        {
            return !String.IsNullOrWhiteSpace(name);
        }
    }
}
