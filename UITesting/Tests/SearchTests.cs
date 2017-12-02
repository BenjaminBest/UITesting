using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting.Tests
{
    /// <summary>
    /// Uses Controls, TextInput, Text, H1 and BUttons
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestClass]
    public class SearchTests : TestBase
    {
        [TestMethod]
        public void SortBar_ShouldContainSearchTerm_WhenSearchIsUsedWithSearchTerm()
        {
            const string searchTerm = "ui testing";

            Go.To<HomePage>().SearchBar.SearchText.Set(searchTerm).SearchBar.SearchButton.Click()
            .SortBar.ResultsCount.Should.Not.BeNull()
            .SortBar.SearchTerm.Should.Contain(searchTerm);
        }
    }
}
