using Atata;

namespace UITesting.Components.Teaser
{
    /// <summary>
    /// The carousel item.
    /// </summary>
    /// <typeparam name="TPage">The type of the page.</typeparam>
    /// <seealso cref="Atata.ListItem{TPage}" />
    public class CarouselWidgetItem<TPage> : ListItem<TPage> where TPage : PageObject<TPage>
    {
    }
}
