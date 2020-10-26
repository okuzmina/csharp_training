using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: ContactTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Contacts.CheckExistingCreateIfNot();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData forRemoving = oldContacts[0];

            applicationManager.Contacts.RemoveById(forRemoving);
            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, forRemoving.Id);
            }
        }
    }
}
