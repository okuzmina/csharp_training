using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            applicationManager.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("nn");
            group.Header = "hh";
            group.Footer = "ff";
            applicationManager.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
        }
    }
}
