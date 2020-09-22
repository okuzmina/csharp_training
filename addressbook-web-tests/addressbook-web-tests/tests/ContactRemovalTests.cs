using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            if (!applicationManager.Contacts.IsContactExist())
            {
                ContactData contactNew = new ContactData("pre-created", "pre-created");
                applicationManager.Contacts.CreateContactWholeProcess(contactNew);
            }

            applicationManager.Contacts.RemoveContactWholeProcess(1);
        }
    }
}
