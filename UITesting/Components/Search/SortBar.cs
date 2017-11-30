using Atata;

namespace UITesting.Components.Search
{
    /// <summary>
    /// The sortbar is located directly below the search and shows the amount of items found and allowed to sort
    /// </summary>
    /// <typeparam name="TPage">The type of the page.</typeparam>
    /// <seealso cref="Atata.Control{TPage}" />
    [ControlDefinition("div", ContainingClass = "searchTemplate", ComponentTypeName = "search template")]
    public class SortBar<TPage> : Control<TPage> where TPage : PageObject<TPage>
    {
        /// <summary>
        /// Gets or sets the results count.
        /// </summary>
        /// <value>
        /// The results count.
        /// </value>
        [FindById("s-result-count")]
        public H1<TPage> ResultsCount { get; set; }

        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        /// <value>
        /// The search term.
        /// </value>
        [FindByClass("a-color-state a-text-bold")]
        public Text<TPage> SearchTerm { get; set; }
    }
}