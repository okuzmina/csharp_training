using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("first", "last");
            contact.Company = "cc";
            contact.Email = "qwe";
            contact.MobilePhone = "123";
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            Logout();
        }
    }
}
