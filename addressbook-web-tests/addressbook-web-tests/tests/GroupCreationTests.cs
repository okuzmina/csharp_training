using NUnit.Framework;
using System.Collections.Generic;

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

            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.CreateGroupWholeProcess(group);

            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count+1, newGroups.Count);
        }
    }
}
