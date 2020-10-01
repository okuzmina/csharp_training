using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupEditionTests: AuthTestBase
    {
        [Test]

        public void GroupEditionTest()
        {
            GroupData group = new GroupData("edit");
            group.Header = "edit";
            group.Footer = "edit";

            applicationManager.Groups.CheckExistngCreateIfNot();
            applicationManager.Groups.EditGroupWholeProcess(0, group);
        }
    }
}
