using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactEditionTests: AuthTestBase
    {
        [Test]

        public void ContactEditionTest()
        {
            ContactData contact = new ContactData("edit", "edit");

            applicationManager.Contacts.CheckExistingCreateIfNot();
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.EditContactWholeProcess(0, contact);
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts[0].LastName = contact.LastName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}