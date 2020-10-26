using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupEditionTests: GroupTestBase
    {
        [Test]

        public void GroupEditionTest()
        {
            GroupData group = new GroupData("edit");
            group.Header = "edit";
            group.Footer = "edit";

            applicationManager.Groups.CheckExistngCreateIfNot();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            applicationManager.Groups.EditById(oldData, group);
            Assert.AreEqual(oldGroups.Count, applicationManager.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = group.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData element in newGroups)
            {
                if (element.Id == oldData.Id)
                {
                    Assert.AreEqual(group.Name, element.Name);
                }
            }
        }
    }
}
