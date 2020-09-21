using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.RemoveGroupWholeProcess(1);
        }
    }
}
