using NUnit.Framework;
using System.Collections.Generic;

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
            List<GroupData> oldGroups = applicationManager.Groups.GetGroupList();

            applicationManager.Groups.EditGroupWholeProcess(0, group);
            List<GroupData> newGroups = applicationManager.Groups.GetGroupList();

            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
