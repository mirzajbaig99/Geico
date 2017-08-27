using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeicoLevelOneWorkshop;
using System.Collections.Generic;
using GeicoLevelOneWorkshop.Data;

namespace GeicoLevelOneWorkshopTest
{
    [TestClass]
    public class AddressContactTypeTest
    {
        [TestMethod]
        public void WorkContactPrintTest()
        {
            // Arrange
            WorkContact contact = new WorkContact("1");
            contact.Name = "Name 1";
            contact.Address = "Address 1";
            contact.PhoneNumber = "23453545434";
            contact.Url = "Url";
            contact.Employer = "Emp";
            contact.Title = eTitle.DR;

            string expectedResult = 
                String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.TaxID,
                    contact.TaxID) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Name),
                   contact.Name) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Address),
                   (contact.Address != null) ? contact.Address : String.Empty) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.PhoneNumber,
                   (contact.PhoneNumber != null) ? contact.PhoneNumber : String.Empty) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Url),
                    contact.Url) +
                     String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Employer),
                    contact.Employer) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Title),
                    contact.Title) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.ModifiedDate,
                    contact.ModifiedDate.ToString(Constants.Defaults.DateFormat)) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.CreatedDate,
                    contact.CreatedDate.ToString(Constants.Defaults.DateFormat));

            // act
            string actualResult = contact.ToString();

            // asset
            StringAssert.Equals(actualResult, expectedResult);
        }

        [TestMethod]
        public void CompanyContactPrintTest()
        {
            // Arrange
            CompanyContact contact = new CompanyContact("1");
            contact.Name = "Name 1";
            contact.Address = "Address 1";
            contact.PhoneNumber = "23453545434";
            contact.Url = "Url";
           

            string expectedResult =
                String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.TaxID,
                    contact.TaxID) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Name),
                   contact.Name) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Address),
                   (contact.Address != null) ? contact.Address : String.Empty) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.PhoneNumber,
                   (contact.PhoneNumber != null) ? contact.PhoneNumber : String.Empty) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Url),
                    contact.Url) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.ModifiedDate,
                    contact.ModifiedDate.ToString(Constants.Defaults.DateFormat)) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.CreatedDate,
                    contact.CreatedDate.ToString(Constants.Defaults.DateFormat));

            // act
            string actualResult = contact.ToString();

            // asset
            StringAssert.Equals(actualResult, expectedResult);
        }

        [TestMethod]
        public void FriendContactPrintTest()
        {
            // Arrange
            FriendContact contact = new FriendContact("1");
            contact.Name = "Name 1";
            contact.Address = "Address 1";
            contact.PhoneNumber = "23453545434";
            contact.Employer = "Emp";
            contact.Birthday = DateTime.Parse("01/30/1999");

            string expectedResult =
                String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.TaxID,
                    contact.TaxID) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Name),
                   contact.Name) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Address),
                   (contact.Address != null) ? contact.Address : String.Empty) +
                   String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.PhoneNumber,
                   (contact.PhoneNumber != null) ? contact.PhoneNumber : String.Empty) +
                     String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Employer),
                    contact.Employer) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.ModifiedDate,
                     String.Format(Constants.Defaults.DefaultPrintFormat, nameof(contact.Birthday),
                    ((contact.Birthday != null) ? contact.Birthday.Value.ToString(Constants.Defaults.DateFormat) : String.Empty)) +
                    contact.ModifiedDate.ToString(Constants.Defaults.DateFormat)) +
                    String.Format(Constants.Defaults.DefaultPrintFormat, Constants.Fields.CreatedDate,
                    contact.CreatedDate.ToString(Constants.Defaults.DateFormat));

            // act
            string actualResult = contact.ToString();

            // asset
            StringAssert.Equals(actualResult, expectedResult);
        }
    }
}
