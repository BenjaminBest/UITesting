using Atata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UITesting.Pages;
using UITesting.TestsCore;

namespace UITesting
{
    [TestClass]
    public class PageObjectTests : TestBase
    {
        [TestMethod]
        public void Home_ShouldHaveCorrectTitle_WhenOpened()
        {
            Go.To<HomePage>().PageTitle.Should
                .Equal(
                    "Amazon.de: Günstige Preise für Elektronik & Foto, Filme, Musik, Bücher, Games, Spielzeug & mehr");
        }
    }
}
