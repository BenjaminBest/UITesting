using Atata;
using UITesting.Components.Search;

namespace UITesting.Pages
{
    /// <summary>
    /// Contains all ui elements which can be found on mostly every page
    /// </summary>
    /// <seealso cref="Atata.Page{UITesting.Pages.HomePage}" />
    public class CommonPage<TPage> : Page<TPage> where TPage : Page<TPage>
    {
        /// <summary>
        /// Gets or sets the search bar.
        /// </summary>
        /// <value>
        /// The search bar.
        /// </value>
        [FindById("twotabsearchtextbox")]
        public TextInput<TPage> SearchBar { get; set; }

        /// <summary>
        /// Gets or sets the search button.
        /// </summary>
        /// <value>
        /// The search button.
        /// </value>
        [FindByClass("nav-input")]
        public Button<TPage> SearchButton { get; set; }

        /// <summary>
        /// Gets or sets the sort bar.
        /// </summary>
        /// <value>
        /// The sort bar.
        /// </value>
        public SortBar<TPage> SortBar { get; set; }
    }
}
