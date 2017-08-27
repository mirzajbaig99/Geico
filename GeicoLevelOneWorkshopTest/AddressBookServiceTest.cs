using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeicoLevelOneWorkshop;
using System.Collections.Generic;

namespace GeicoLevelOneWorkshopTest
{
    [TestClass]
    public class AddressBookServiceTest
    {
        [TestMethod]
        public void MainMenuInvalidSelectionFail()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "dddddee8766",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.InvalidCommand);
        }

        [TestMethod]
        public void SearchMenuInvalidSelectionFail()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "2",
                    "dddddee8766",
                    "",
                    "3",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.InvalidCommand);
        }

        [TestMethod]
        public void AddMenuInvalidSelectionFail()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "dddddee8766",
                    "",
                    "4",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.InvalidCommand);
        }

        [TestMethod]
        public void AddCompanyContactInvalidNameSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "1",
                    "1",
                    "",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, String.Format(Constants.Messages.FieldCannotBeNull,"Name"));
        }

        [TestMethod]
        public void AddCompanyContactInvalidTaxIDSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "1",
                    "abc",
                    "",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.invalidTaxIDMessage);
        }

        [TestMethod]
        public void AddCompanyContactUniqueTaxIDSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "1",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "1",
                    "1",
                    "1",
                    "",
                    "2",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.taxIDAlreadyExsists);
        }

        [TestMethod]
        public void AddCompanyContactSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "1",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole,rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output,Constants.Messages.SuccessfullyAdded);
        }

        [TestMethod]
        public void AddWorkContactTestSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "2",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "Emp",
                    "email",
                    "NONE",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole,rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyAdded);
        }

        [TestMethod]
        public void AddWorkContactTestInvalidTitle()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "2",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "Emp",
                    "email",
                    "NON",
                    "",
                    "NOnE",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.InvalidTitle);
        }

        [TestMethod]
        public void EditContactNotFound()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "3",
                    "1",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.ContactNotFound);
        }

        [TestMethod]
        public void AddFriendContactEmptyTaxIDTest()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "",
                    "",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyAdded);
        }

        [TestMethod]
        public void AddFriendContactTestSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "5" });
            AddressBookService target = new AddressBookService(fakeConsole,rep);

            // act
            target.Start();

            // asset
            Assert.IsNotNull(rep.SearchByTaxID("1"));
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyAdded);
        }

        [TestMethod]
        public void EditCompanyContactSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "1",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "",
                    "3",
                    "1",
                     "Name 2",
                    "Address 2",
                    "1243545462",
                    "www.google.com",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole,rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyUpdated);
        }

        [TestMethod]
        public void EditWorkContactTestSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "2",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "www.google.com",
                    "Emp",
                    "email",
                    "Dr",
                    "",
                    "3",
                    "1",
                     "Name 2",
                    "Address 2",
                    "1243545462",
                    "www.yahoo.com",
                    "Emp 2",
                    "email updated",
                    "Mr",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyUpdated);
        }

        [TestMethod]
        public void EditFriendContactTestSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "3",
                     "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole,rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.SuccessfullyUpdated);
        }

        [TestMethod]
        public void SearchContactByTaxIDSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "2",
                    "1",
                    "1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, String.Format(Constants.Messages.recordMatched,"1"));
        }

        [TestMethod]
        public void SearchContactByTaxIDFailContactNotFound()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    
                    "2",
                    "1",
                    "1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.ContactNotFound);
        }

        [TestMethod]
        public void SearchContactByNameSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                     "1",
                    "3",
                    "2",
                    "Name 1",
                    "Address 2",
                    "1243545462",
                    "01/01/1998",
                    "email",
                    "",
                    "2",
                     "2",
                    "Name 1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, String.Format(Constants.Messages.recordMatched, "2"));
        }


        [TestMethod]
        public void SearchContactByNameFailContactNotFound()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "2",
                    "2",
                    "Name 1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, Constants.Messages.ContactNotFound);
        }

        [TestMethod]
        public void DeleteContactSuccess()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "1",
                    "3",
                    "1",
                    "Name 1",
                    "Address 1",
                    "1243545462",
                    "01/01/1999",
                    "email",
                    "",
                    "4",
                    "1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, String.Format(Constants.Messages.SuccessfullyDeleted));
        }

        [TestMethod]
        public void DeleteFailContactNotFound()
        {
            // Arrange
            IRepAddressBook rep = new RepAddressBook();
            FakeConsoleInterface fakeConsole = new FakeConsoleInterface(
                new List<string>
                {
                    "4",
                    "1",
                    "",
                    "5"});
            AddressBookService target = new AddressBookService(fakeConsole, rep);

            // act
            target.Start();

            // asset
            StringAssert.Contains(fakeConsole.Output, String.Format(Constants.Messages.ContactNotFound));
        }
    }
}
