using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("first", "last");
            contact.Company = "cc";
            contact.Email = "qwe";
            contact.MobilePhone = "123";
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.CreateContactWholeProcess(contact);
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
