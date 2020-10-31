using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTest
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        { 
            List<ContactData> oldList = ContactData.GetContactsWithoutGroup();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            applicationManager.Contacts.RemoveFirstContactFromGroup(contact);

            List<ContactData> newList = ContactData.GetContactsWithoutGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
