using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupEditionTests: TestBase
    {
        [Test]

        public void GroupEditionTest()
        {
            applicationManager.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("edit");
            group.Header = "edit";
            group.Footer = "edit";
            applicationManager.Groups
                .SelectGroup(2)
                .EditGroup()
                .FillGroupForm(group)
                .UpdateGroup()
                .ReturnToGroupsPage();
        }
    }
}
