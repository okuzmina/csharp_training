using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Navigator.GoToGroupsPage();
            applicationManager.Groups
                .SelectGroup(2)
                .RemoveGroup()
                .ReturnToGroupsPage();
        }
    }
}
