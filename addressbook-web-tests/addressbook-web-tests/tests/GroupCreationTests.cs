using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTests : TestBase
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
