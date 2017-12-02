using UITesting.Components.Teaser;
using _ = UITesting.Pages.HomePage;

namespace UITesting.Pages
{
    /// <summary>
    /// The homepage
    /// </summary>
    /// <seealso cref="Pages.CommonPage{_}" />
    public class HomePage : CommonPage<_>
    {
        /// <summary>
        /// Gets or sets the carousel teaser
        /// </summary>
        /// <value>
        /// The carousel.
        /// </value>
        public CarouselWidget<_> CarouselTeaser { get; set; }
    }
}
