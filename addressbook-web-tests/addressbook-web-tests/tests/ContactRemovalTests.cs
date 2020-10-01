using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: AuthTestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Contacts.CheckExistingCreateIfNot();
            applicationManager.Contacts.RemoveContactWholeProcess(0);
        }
    }
}
