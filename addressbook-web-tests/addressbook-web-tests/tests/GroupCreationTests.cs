using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("nn");
            group.Header = "hh";
            group.Footer = "ff";
            applicationManager.Groups.CreateGroupWholeProcess(group);
        }
    }
}
