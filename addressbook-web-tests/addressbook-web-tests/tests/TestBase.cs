using NUnit.Framework;

namespace WebAddressbookTest
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;
        [SetUp]
        public void SetupApplicationManager()
        {
            applicationManager = ApplicationManager.GetInstance();
        }
    }
}
