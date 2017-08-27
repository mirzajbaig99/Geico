namespace GeicoLevelOneWorkshop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            new AddressBookService(new Console(),new RepAddressBook()).Start();
        }
    }
}
