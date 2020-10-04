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
            ContactData oldData = oldContacts[0];

            applicationManager.Contacts.EditContactWholeProcess(0, contact);
            Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts[0].LastName = contact.LastName;
            oldContacts[0].FirstName = contact.FirstName;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData element in newContacts)
            {
                if (element.Id == oldData.Id)
                {
                    Assert.AreEqual(contact.LastName, element.LastName);
                    Assert.AreEqual(contact.FirstName, element.FirstName);
                }
            }
        }
    }
}