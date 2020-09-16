using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.RemoveGroupWholeProcess(1);
        }
    }
}
