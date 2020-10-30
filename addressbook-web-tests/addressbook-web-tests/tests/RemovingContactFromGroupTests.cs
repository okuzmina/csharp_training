﻿using System;
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
            List<ContactData> oldList = GetContactsWithoutGroup();

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            applicationManager.Contacts.RemoveFirstContactFromGroup(contact);

            List<ContactData> newList = GetContactsWithoutGroup();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }

        public List<ContactData> GetContactsWithoutGroup()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p =>
                        p.ContactId == c.Id &&
                        p.GroupId.Count() == 0)
                        select c).Distinct().ToList();
            }
        }
    }
}
