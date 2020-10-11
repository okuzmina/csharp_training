using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(10), GenerateRandomString(20))
                {
                    Address = GenerateRandomString(100),
                });
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = applicationManager.Contacts.GetContactList();

            applicationManager.Contacts.CreateContactWholeProcess(contact);
            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contacts.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
