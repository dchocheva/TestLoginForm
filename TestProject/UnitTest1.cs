using NUnit.Framework;
using Framework;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Driver.ChromeDriverInit();
            CommonForAll.Init();
            Browser.OpenWebSite();
        }

        [TearDown]
        public static void AfterSingleTest()
        {

            Driver.CloseBrowser();
        }

        [Test]
        public void Test1()
        {            
            string my = "My String";
            Assert.Pass();
        }
    }
}