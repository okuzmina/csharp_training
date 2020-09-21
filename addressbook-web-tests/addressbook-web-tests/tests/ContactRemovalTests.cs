﻿using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Contacts.RemoveContactWholeProcess(1);
        }
    }
}
