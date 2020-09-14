using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: TestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Contacts
                .SelectContact(1)
                .RemoveContact()
                .DeleteConfirmation();
            applicationManager.Navigator.ReturnToHomePage();
        }
    }
}
