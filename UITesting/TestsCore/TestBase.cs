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
        /// <summary>
        /// Gets or sets the test context.
        /// </summary>
        /// <value>
        /// The test context.
        /// </value>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Initialize.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            AtataContext.Configure()
                .UseChrome().WithArguments("disable-extensions", "no sandbox", "start-maximized")
                .UseBaseUrl(Configuration.BaseUrl)
                .UseTestName(TestContext.TestName)
                .AddNLogLogging()
                .UseCulture("de-de")
                .AddTraceLogging()
                .AddScreenshotFileSaving()
                .WithFolderPath(() => $@"Logs\{AtataContext.BuildStart:yyyy-MM-dd HH_mm}")
                .WithFileName(screenshotInfo => $"{AtataContext.Current.TestName} - {screenshotInfo.PageObjectFullName}")
                .Build();
        }

        /// <summary>
        /// Cleanup.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            AtataContext.Current.CleanUp();
        }
    }
}
