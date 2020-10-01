using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.CheckExistngCreateIfNot();
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.RemoveGroupWholeProcess(0);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
