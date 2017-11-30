using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITesting.TestsCore
{
    /// <summary>
    /// The class TestBase is used to setup the testing framework and the web driver
    /// </summary>
    [TestClass]
    public class TestBase
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            AtataContext.Configure()
                .UseChrome().WithArguments("disable-extensions", "no sandbox", "start-maximized")
                .UseBaseUrl(Configuration.BaseUrl)
                .UseTestName(TestContext.TestName)
                //.UseNUnitTestName()
                //.AddNUnitTestContextLogging().WithoutSectionFinish()
                .AddNLogLogging()
                .UseCulture("de-de")
                .AddTraceLogging()
                //.LogNUnitError()
                .TakeScreenshotOnNUnitError()
                .Build();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            AtataContext.Current.CleanUp();
        }
    }
}
