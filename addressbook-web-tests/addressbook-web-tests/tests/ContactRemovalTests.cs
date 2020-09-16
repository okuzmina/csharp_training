using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]

    public class ContactRemovalTests: TestBase
    {
        [Test]

        public void ContactRemovalTest()
        {
            applicationManager.Contacts.RemoveContactWholeProcess(1);
        }
    }
}
