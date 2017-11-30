using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting
{
    [TestClass]
    public class TextInputTests : TestBase
    {
        [TestMethod]
        public void SortBar_ShouldContainSearchTerm_WhenSearchIsUsedWithSearchTerm()
        {
            const string searchTerm = "ui testing";

            Go.To<HomePage>().SearchBar.Set(searchTerm).SearchButton.Click()
            .SortBar.ResultsCount.Should.Not.BeNull()
            .SortBar.SearchTerm.Should.Contain(searchTerm);
        }
    }
}
