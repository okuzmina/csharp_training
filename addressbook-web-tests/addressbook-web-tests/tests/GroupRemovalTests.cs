using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Groups.CheckExistngCreateIfNot();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData forRemoving = oldGroups[0];

            applicationManager.Groups.RemoveById(forRemoving);

            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, forRemoving.Id);
            }
        }
    }
}
