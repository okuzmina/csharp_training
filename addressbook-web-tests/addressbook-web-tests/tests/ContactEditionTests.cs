using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactEditionTests: AuthTestBase
    {
        [Test]

        public void ContactEditionTest()
        {
            ContactData contact = new ContactData("edit", "edit");

            if (!applicationManager.Contacts.IsContactExist())
            {
                ContactData contactNew = new ContactData("pre-created", "pre-created");
                applicationManager.Contacts.CreateContactWholeProcess(contactNew);
            }

            applicationManager.Contacts.EditContactWholeProcess(1, contact);
        }
    }
}
