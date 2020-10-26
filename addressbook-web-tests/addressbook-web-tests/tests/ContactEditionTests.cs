using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactEditionTests: ContactTestBase
    {
        [Test]

        public void ContactEditionTest()
        {
            ContactData contact = new ContactData("edit", "edit");

            applicationManager.Contacts.CheckExistingCreateIfNot();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            applicationManager.Contacts.EditById(oldData, contact);
            Assert.AreEqual(oldContacts.Count, applicationManager.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();

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