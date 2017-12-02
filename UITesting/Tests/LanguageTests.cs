using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting.Tests
{
    /// <summary>
    /// Uses controls, ordered list, screenshot, link and link delegate, attribute selector
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestClass]
    public class LanguageTests : TestBase
    {
        [TestMethod]
        public void LanguageSwitch_ShouldBeVisible_WhenLanguageButtonWasClicked()
        {
            Go.To<HomePage>().Header.LanguageSwitch.Hover();

            //Manually using the driver, see https://github.com/atata-framework/atata-webdriverextras
            var driver = AtataContext.Current.Driver;
            var element = driver.Get(By.Id("nav-flyout-icp").OfAnyVisibility().AtOnce());

            Assert.IsTrue(element.Displayed);
        }
    }
}
