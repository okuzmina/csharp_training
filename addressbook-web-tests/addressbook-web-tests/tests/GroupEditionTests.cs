using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupEditionTests: TestBase
    {
        [Test]

        public void GroupEditionTest()
        {
            GroupData group = new GroupData("edit");
            group.Header = "edit";
            group.Footer = "edit";
            applicationManager.Groups.EditGroupWholeProcess(2, group);
        }
    }
}
