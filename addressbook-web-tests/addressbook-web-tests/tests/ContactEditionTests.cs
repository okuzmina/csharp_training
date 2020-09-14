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
            applicationManager.Contacts
                .EditContact(2)
                .FillContactForm(contact)
                .UpdateContact();
            applicationManager.Navigator.ReturnToHomePage();
        }
    }
}
