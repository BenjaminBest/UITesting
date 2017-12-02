using Atata;

namespace UITesting.Components.Teaser
{
    /// <summary>
    /// The searchbar contains the search input textbox and the search button
    /// </summary>
    /// <typeparam name="TPage">The type of the page.</typeparam>
    /// <seealso cref="Atata.Control{TPage}" />
    [ControlDefinition("div", ContainingClass = "a-carousel-row", ComponentTypeName = "carousel")]
    public class CarouselWidget<TPage> : Control<TPage> where TPage : PageObject<TPage>
    {
        /// <summary>
        /// Gets or sets the previous button.
        /// </summary>
        /// <value>
        /// The previous.
        /// </value>
        [Screenshot("BeforeClick")]
        [Screenshot("AfterClick", TriggerEvents.AfterClick)]
        [FindByClass("a-carousel-goto-prevpage")]
        public LinkDelegate<TPage> Prev { get; set; }

        /// <summary>
        /// Gets or sets the next button.
        /// </summary>
        /// <value>
        /// The next.
        /// </value>
        [Screenshot("BeforeClick")]
        [Screenshot(On = TriggerEvents.AfterClick, AppliesTo = TriggerScope.Children)]
        [FindByClass("a-carousel-goto-nextpage")]
        public LinkDelegate<TPage> Next { get; set; }

        /// <summary>
        /// Gets or sets the carousel items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        [FindByClass("a-carousel")]
        public OrderedList<CarouselWidgetItem<TPage>, TPage> Items { get; set; }
    }
}