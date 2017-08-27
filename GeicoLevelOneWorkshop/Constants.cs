using GeicoLevelOneWorkshop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeicoLevelOneWorkshop
{
    public static class Constants
    {
        public static class Defaults
        {
            public const string DateFormat = "MM/dd/yyyy";
            public const string DefaultPrintFormat = "{0} : {1}\n";
            public const string RecordBreak = "===========================================\n";
        }

        public static class Messages
        {
            public const string ValidTitles = "Note: Valid Title Values (None, Mr. , Mrs. , Miss, Dr.)";
            public const string InvalidTitle = "Invalid Title Valid Title Values (None, Mr. , Mrs. , Miss, Dr.)";
            public const string recordMatched = "{0} Records Matched.";
            public const string recordIndex = "Record {0}\n";
            public const string CurrentValue = "CurrentValue : {0}";
            public const string NewValue = "Enter New Value : ";
            public const string UpdateFieldValueMessage = " Update {0}{1}";
            public const string FieldValueMessage = "{0}{1} : ";
            public const string invalidTaxIDMessage = "Invalid Tax ID. Tax ID should be numeric, between 1 and 9 digit";
            public const string taxIDAlreadyExsists = "Tax ID already exsists in the system, Tax ID must be unique";
            public const string FieldCannotBeNull = "{0} cannot be null";
            public const string InvalidCommand = "Invalid Command Number, Please enter a valid command";
            public const string InvalidDateFormat = "Invalid Date Format please enter mm/dd/yyyy.";
            public const string PressEnterToContinue = "Perss Enter to continue...";
            public const string SuccessfullyAdded = "Successfully Added";
            public const string SuccessfullyUpdated = "Successfully Updated";
            public const string SuccessfullyDeleted = "Successfully Deleted";
            public static string ContactNotFound = "Contact not found";
        }

        public static class Fields
        {
            public const string TaxID = "Tax ID";
            public const string PhoneNumber = "Phone Number";
            public const string ModifiedDate = "Modified Date";
            public const string CreatedDate = "Created Date";
        }
        public static class Menu
        {
            public const string ListOfCommands = "Main Menu \n"
                                                + "Type the Command Number and press enter:\n"
                                                + "1. Add (To add a contact)\n"
                                                + "2. Search (To search a contact)\n"
                                                + "3. Edit (To Edit an exsisting contact)\n"
                                                + "4. Delete (To delete a contact)\n"
                                                + "5. Exit (To Quit)\n";

            public const string ListOfSearchCommands = "Search Menu\n"
                                                        + "Type the Command Name below and press enter:\n"
                                                        + "1. TaxID (Search by TaxID)\n"
                                                        + "2. Name (Search by Name)\n"
                                                        + "3. Back to Main Menu\n";

            public const string ListOfAddCommands = "Add Contact Type\n"
                                                        + "Type the Number Corresponding to Contact Type to Add below and press enter:\n"
                                                        + "1. Company\n"
                                                        + "2. Work\n"
                                                        + "3. Friend\n"
                                                        + "4. Back to Main Menu\n";

            public const string Prompt = ":";
        }
        public static class Mappings
        {
            public static Dictionary<eTitle, string> eTitleMapping =
                                        new Dictionary<eTitle, string>() { {eTitle.NONE, "None"},
                                                                           {eTitle.MR, "Mr."},
                                                                           {eTitle.MRS, "Mrs"},
                                                                           {eTitle.MISS, "Miss"},
                                                                           {eTitle.DR, "Dr."}};
        }
    }
}
