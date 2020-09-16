using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("first", "last");
            contact.Company = "cc";
            contact.Email = "qwe";
            contact.MobilePhone = "123";
            applicationManager.Contacts.CreateContactWholeProcess(contact);
        }
    }
}
