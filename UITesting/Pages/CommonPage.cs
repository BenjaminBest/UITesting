using Atata;
using UITesting.Components.Navigation;
using UITesting.Components.Search;

namespace UITesting.Pages
{
    /// <summary>
    /// Contains all ui elements which can be found on mostly every page
    /// </summary>
    /// <seealso cref="Atata.Page{HomePage}" />
    public class CommonPage<TPage> : Page<TPage> where TPage : Page<TPage>
    {
        /// <summary>
        /// Gets or sets the search bar.
        /// </summary>
        /// <value>
        /// The search bar.
        /// </value>
        public SearchBar<TPage> SearchBar { get; set; }

        /// <summary>
        /// Gets or sets the sort bar.
        /// </summary>
        /// <value>
        /// The sort bar.
        /// </value>
        public SortBar<TPage> SortBar { get; set; }

        [FindById("navbar")]
        public Header<TPage> Header { get; set; }
    }
}
