using Atata;

namespace UITesting.Components.Search
{
    /// <summary>
    /// The searchbar contains the search input textbox and the search button
    /// </summary>
    /// <typeparam name="TPage">The type of the page.</typeparam>
    /// <seealso cref="Atata.Control{TPage}" />
    [ControlDefinition("form", ContainingClass = "nav-searchbar", ComponentTypeName = "nav searchbar")]
    public class SearchBar<TPage> : Control<TPage> where TPage : PageObject<TPage>
    {
        /// <summary>
        /// Gets or sets the search bar.
        /// </summary>
        /// <value>
        /// The search bar.
        /// </value>
        [FindById("twotabsearchtextbox")]
        public TextInput<TPage> SearchText { get; set; }

        /// <summary>
        /// Gets or sets the search button.
        /// </summary>
        /// <value>
        /// The search button.
        /// </value>
        [FindByClass("nav-input")]
        public Button<TPage> SearchButton { get; set; }
    }
}