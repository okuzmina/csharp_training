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
            applicationManager.Contacts.EditContactWholeProcess(1, contact);
        }
    }
}
