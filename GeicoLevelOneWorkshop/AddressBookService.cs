
namespace GeicoLevelOneWorkshop
{
    using GeicoLevelOneWorkshop.Data;
    using GeicoLevelOneWorkshop.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
   
    public class AddressBookService
    {
       
        private const string prompt = ":";

        IConsole consoleService;
        readonly IRepAddressBook AddressBook;
        public AddressBookService(IConsole console,IRepAddressBook rep)
        {
            this.consoleService = console;
            this.AddressBook = rep;
        }

        public void Start()
        {
            bool runNextCommand = true;
            while(runNextCommand)
            {
                consoleService.Write(Constants.Menu.ListOfCommands);
                consoleService.Write(Constants.Menu.Prompt);
                string command = this.consoleService.ReadLine();

                switch(command.Trim())
                {
                    case "1":
                        {
                            this.AddContact();
                            break;
                        }
                    case "2":
                        {
                            this.SearchContact();
                            break;
                        }
                    case "3":
                        {
                            this.EditContact();
                            break;
                        }
                    case "4":
                        {
                            this.DeleteContact();
                            break;
                        }
                    case "5":
                        {
                            runNextCommand = false;
                            break;
                        }
                    default:
                        {
                            InvalidSelection();
                            break;
                       }
                }

            }
            
        }

        private void EditContact()
        {
            string taxId = ReadTaxID(false);
            Contact contact = this.AddressBook.SearchByTaxID(taxId);
            if(contact == null)
            {
                consoleService.WriteLine(Constants.Messages.ContactNotFound);
                PressEnterToContinue();
            }else
            {
                this.BuildContact(contact,true);
            }

        }
      
        private void DeleteContact()
        {
            try {
                this.AddressBook.DeleteContact(ReadTaxID(false));
                consoleService.WriteLine(Constants.Messages.SuccessfullyDeleted);
            }
            catch(ExceptionContactNotFound)
            {
                consoleService.WriteLine(Constants.Messages.ContactNotFound);
            }
            PressEnterToContinue();
        }

        private void SearchContact()
        {
            bool runNextCommand;
            do
            {
                runNextCommand = false;
                printListOfSearchCommands();
                string subCommand = this.consoleService.ReadLine().Trim();
                switch (subCommand)
                {
                    case "1":
                        {
                            Contact c = this.AddressBook.SearchByTaxID(ReadTaxID(false));
                            if(c != null)
                            {
                                consoleService.WriteLine(Constants.Messages.recordMatched, "1");
                                consoleService.Write(Constants.Defaults.RecordBreak);
                                consoleService.Write(c.ToString());
                            }else
                            {
                                consoleService.WriteLine(Constants.Messages.ContactNotFound);
                            }
                            this.PressEnterToContinue();
                            break;
                        }
                    case "2":
                        {
                            List<Contact> c = this.AddressBook.SearchByName(ReadValueCannotBeEmpty("Name"));
                            if (c != null && c.Count > 0)
                            {
                                consoleService.WriteLine(Constants.Messages.recordMatched,c.Count);
                                List<string> record = c.Select((s, index) => {
                                    return
                                    Constants.Defaults.RecordBreak +
                                    String.Format(Constants.Messages.recordIndex, index)
                                     + s.ToString(); }).ToList();
                                foreach (string print in record)
                                {
                                    consoleService.Write(print);
                                }
                            }
                            else
                            {
                                consoleService.WriteLine(Constants.Messages.ContactNotFound);
                            }
                            this.PressEnterToContinue();
                            break;
                        }
                    case "3":
                        {
                            break;
                        }
                    default:
                        {
                            InvalidSelection();
                            runNextCommand = true;
                            break;
                        }
                }
            } while (runNextCommand);
        }
        private void AddContact()
        {
            bool runNextCommand;
            do
            {
                runNextCommand = false;
                printListOfAddCommands();
                string subCommand = this.consoleService.ReadLine().Trim();
                switch (subCommand)
                {
                    case "1":
                        {
                            CompanyContact contact = new CompanyContact(ReadTaxID(true));
                            BuildContact(contact);
                            break;
                        }
                    case "2":
                        {
                            WorkContact contact = new WorkContact(ReadTaxID(true));
                            BuildContact(contact);
                            break;
                        }
                    case "3":
                        {
                            FriendContact contact = new FriendContact(ReadTaxID(true));
                            BuildContact(contact);
                            break;
                        }
                    case "4":
                        {
                            break;
                        }
                    default:
                        {
                            InvalidSelection();
                            runNextCommand = true;
                            break;
                        }
                }
            } while (runNextCommand);
        }

        private eTitle ReadTitle()
        {
            bool InvalidTitle = true;
            eTitle validTitle = eTitle.NONE;
            do
            {
                consoleService.WriteLine(Constants.Messages.ValidTitles);
                string title = ReadValueFromUser("Title").ToUpper();
                if (Enum.TryParse(title, out validTitle))
                {
                    InvalidTitle = false;
                }else
                {
                    consoleService.WriteLine(Constants.Messages.InvalidTitle);
                    this.PressEnterToContinue();
                }


            } while (InvalidTitle);
            return validTitle;
         }
        private string ReadTaxID(bool checkUniqueContraint)
        {
            bool validTaxID = false;
            string taxid = String.Empty;
            do
            {
                taxid = ReadValueFromUser(Constants.Fields.TaxID);
                validTaxID = Validations.ValidateTaxID(taxid);
                if(!validTaxID)
                {
                    consoleService.WriteLine(Constants.Messages.invalidTaxIDMessage);
                    PressEnterToContinue();
                    continue;
                }
                if (checkUniqueContraint)
                {
                    try
                    {
                        this.AddressBook.IsExists(taxid);
                    }
                    catch (TaxIdUniqueException ex)
                    {
                        validTaxID = false;
                        consoleService.WriteLine(ex.Message);
                        PressEnterToContinue();
                    }
                }

            } while (!validTaxID);

            return taxid;
        }
        public void BuildContact(Contact addEntry, bool isUpdate = false)
        {
            addEntry.Name = ReadValueCannotBeEmpty(nameof(addEntry.Name),addEntry.Name,isUpdate);
            addEntry.Address = ReadValueFromUser(nameof(addEntry.Address), addEntry.Address, isUpdate);
            addEntry.PhoneNumber = ReadValueFromUser(Constants.Fields.PhoneNumber, addEntry.PhoneNumber, isUpdate);
            
            if(addEntry is CompanyContact)
            {
                CompanyContact cContact = (CompanyContact)addEntry;
                cContact.Url = ReadValueFromUser(nameof(cContact.Url), cContact.Url, isUpdate);
            }else if(addEntry is WorkContact)
            {
                WorkContact wContact = (WorkContact)addEntry;
                wContact.Url = ReadValueFromUser(nameof(wContact.Url), wContact.Url, isUpdate);
                wContact.Employer = ReadValueFromUser(nameof(wContact.Employer), wContact.Employer, isUpdate);
                wContact.Email = ReadValueFromUser(nameof(wContact.Email), wContact.Email, isUpdate);
                wContact.Title = ReadTitle();
            }else if(addEntry is FriendContact)
            {
                FriendContact fContact = (FriendContact)addEntry;
                fContact.Birthday = ReadDateValue(nameof(fContact.Birthday), fContact.Birthday, isUpdate);
                fContact.Email = ReadValueFromUser(nameof(fContact.Email), fContact.Email, isUpdate);

            }
            if (isUpdate)
            {
                addEntry.ModifiedDate = DateTime.Now;
            }
            this.AddressBook.Add(addEntry);
            if (isUpdate)
            {
                consoleService.WriteLine(Constants.Messages.SuccessfullyUpdated);
            }
            else
            {
                consoleService.WriteLine(Constants.Messages.SuccessfullyAdded);
            }
            PressEnterToContinue();

        }

        private DateTime? ReadDateValue(string FieldName,DateTime? currentValue = null,bool ShowCurrentValue = false)
        {
            DateTime retval;
            bool InvalidInput = true;
            do
            {
                string input = this.ReadValueFromUser(
                                    FieldName, 
                                    (currentValue != null)?currentValue.Value.ToString(Constants.Defaults.DateFormat):String.Empty,
                                    ShowCurrentValue, true);
                if (String.IsNullOrWhiteSpace(input))
                {
                    return null;
                }
                if (DateTime.TryParseExact(input, Constants.Defaults.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out retval))
                {
                    InvalidInput = false;
                }
                else
                {
                    consoleService.WriteLine(Constants.Messages.InvalidDateFormat);
                }
            } while (InvalidInput);

            return retval;
        }
        private string ReadValueCannotBeEmpty(string FieldName,string CurrentValue = null,bool showCurrentValue = false)
        {
            string retval = null;
            do
            {
                retval = this.ReadValueFromUser(FieldName, CurrentValue, showCurrentValue);
                if(!String.IsNullOrWhiteSpace(retval))
                {
                    return retval;
                }
                consoleService.WriteLine(Constants.Messages.FieldCannotBeNull, FieldName);
            } while (true);

           
        }
        private string ReadValueFromUser(string FieldName, string feildValue = null, bool showCurrentValue = false, bool isDateTimeValue = false)
        {
            if (showCurrentValue)
            {
                consoleService.WriteLine(Constants.Messages.UpdateFieldValueMessage, FieldName,
                    ((isDateTimeValue) ? " (Date Format - mm/dd/yyyy)" : String.Empty));
                consoleService.WriteLine(Constants.Messages.CurrentValue, feildValue);
                consoleService.Write(Constants.Messages.NewValue);
            }else
            {
                consoleService.Write(String.Format(Constants.Messages.FieldValueMessage, FieldName,
                ((isDateTimeValue) ? " (Date Format - mm/dd/yyyy)" : String.Empty)));
            }
            return consoleService.ReadLine().Trim();
        }
        
        public void printListOfSearchCommands()
        {
            consoleService.Write(Constants.Menu.ListOfSearchCommands);
            consoleService.Write(Constants.Menu.Prompt);
        }

        public void printListOfAddCommands()
        {
            consoleService.Write(Constants.Menu.ListOfAddCommands);
            consoleService.Write(Constants.Menu.Prompt);
        }

        public void InvalidSelection()
        {
            consoleService.WriteLine(Constants.Messages.InvalidCommand);
            PressEnterToContinue();
        }

        public void PressEnterToContinue()
        {
            consoleService.Write(Constants.Messages.PressEnterToContinue);
            consoleService.ReadLine();
        }
    }

   
}
