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
            // Хочу найти в бд и сохранить список контактов, которые не были добавлены в группы
            // Но непонятно, как именно это реализовать 
            List<ContactData> oldList = ?????GetContactsWithoutGroup();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            applicationManager.Contacts.RemoveFirstContactFromGroup(contact);

            List<ContactData> newList = c.GetContactsWithoutGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
