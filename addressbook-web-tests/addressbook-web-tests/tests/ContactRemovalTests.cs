using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Contacts.CheckExistingCreateIfNot();
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.RemoveContactWholeProcess(0);
            Assert.AreEqual(oldContacts.Count - 1, applicationManager.Contacts.GetContactCount());
            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
