using NUnit.Framework;

namespace WebAddressbookTest
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;
        [SetUp]
        public void SetupTest()
        {
            applicationManager = new ApplicationManager();
            applicationManager.Navigator.OpenHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            applicationManager.Auth.Logout();
            applicationManager.Stop();
        }
    }
}
