using Atata;

namespace UITesting.Components.Navigation
{
    /// <summary>
    /// The header includes functions like the language switch, orders & account, categories
    /// </summary>
    /// <typeparam name="TPage">The type of the page.</typeparam>
    /// <seealso cref="Atata.Control{TPage}" />
    public class Header<TPage> : Control<TPage> where TPage : PageObject<TPage>
    {
        /// <summary>
        /// Gets or sets the search bar.
        /// </summary>
        /// <value>
        /// The search bar.
        /// </value>
        [FindById("icp-nav-flyout")]
        public Link<TPage> LanguageSwitch { get; set; }


    }
}