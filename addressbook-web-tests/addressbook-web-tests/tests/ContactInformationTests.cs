using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest 
{
    [TestFixture]
    public class ContactInformationTests: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = applicationManager.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestIndividualContactInformation()
        {
            ContactData fromForm = applicationManager.Contacts.GetContactInformationFromEditForm(0);
            string individualView = applicationManager.Contacts.GetContactInformationIndividualView(0);

            Assert.AreEqual(fromForm.AllDetails, individualView);
        }
    }
}
