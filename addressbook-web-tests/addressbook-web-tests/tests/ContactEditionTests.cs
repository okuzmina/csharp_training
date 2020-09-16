using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactEditionTests: TestBase
    {
        [Test]

        public void ContactEditionTest()
        {
            ContactData contact = new ContactData("edit", "edit");
            applicationManager.Contacts.EditContactWholeProcess(2, contact);
        }
    }
}
