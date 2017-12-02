using Atata;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting.Tests
{
    /// <summary>
    /// Uses controls, link, fluent assertions and using selenium directly (https://github.com/atata-framework/atata-webdriverextras)
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestClass]
    public class LanguageTests : TestBase
    {
        [TestMethod]
        public void LanguageSwitch_ShouldBeVisible_WhenLanguageButtonWasClicked()
        {
            Go.To<HomePage>().Header.LanguageSwitch.Hover();
            var element = AtataContext.Current.Driver.Get(By.Id("nav-flyout-icp").OfAnyVisibility().AtOnce());

            element.Displayed.Should().BeTrue();
        }
    }
}
