using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting.Tests
{
    /// <summary>
    /// Uses controls, ordered list, screenshot, link and link delegate, attribute selector
    /// </summary>
    /// <seealso cref="TestBase" />
    [TestClass]
    public class SliderTests : TestBase
    {
        [TestMethod]
        public void CarouselTeaser_ShouldSlide_WhenNextButtonIsClicked()
        {
            Go.To<HomePage>().CarouselTeaser.Next();
        }

        [TestMethod]
        public void CarouselTeaser_ShouldSlide_WhenPrevButtonIsClicked()
        {
            Go.To<HomePage>().CarouselTeaser.Prev();
        }

        [TestMethod]
        public void CarouselTeaser_ShouldHaveCorrectItemCount_WhenPageOpened()
        {
            Go.To<HomePage>().CarouselTeaser.Items.Items.Count.Should.Equal(7);
        }
    }
}
