using NUnit.Framework;

namespace WebAddressbookTest
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!applicationManager.Groups.IsGrouptExist())
            {
                GroupData groupNew = new GroupData("pre-created");
                applicationManager.Groups.CreateGroupWholeProcess(groupNew);
            }

            applicationManager.Groups.RemoveGroupWholeProcess(1);
        }
    }
}
