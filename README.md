Automated UI Testing
=====================================
Before implementing and establishing automated UI tests in a project lots of questions should be answered.

For the use case I'm testing for, these decicions were made
1. A "real" browser is needed, no emulation
2. The [Selenium](https://github.com/SeleniumHQ/selenium) web driver should be used, cause a selenium grid is already in place
3. A framework needed, because using Selenium will lead to messy and not maintainable code. The question is, if an existent one is good enough to work with quite a long time horizon. Also the framwork should not be dead when starting this project
4. Which patterns should/can be used to develop maintainable code and supports quick creation of unit tests
5. MS Test should be used
6. Are the UI tests stable and do not lead to lots of false positives

A VS test solution shall be created which uses [Atata Framework](https://atata-framework.github.io/). Then unit tests for [Amazon](https://www.amazon.de/) will be written to test the framework and the reliability of both, [Selenium](https://github.com/SeleniumHQ/selenium) and [Atata Framework](https://atata-framework.github.io/).

This document contains a step by step guide of what was done.

Setup
--------------
### VS Solution
A new solution was created with one Unit Test Project based on .NET Framework 4.7

### Installation of the NuGet packages
These packages have been installed:
1. https://www.nuget.org/packages/Atata/0.15.0/
2. https://www.nuget.org/packages/Atata.WebDriverExtras/0.13.0/

Automatically these packages were installed because of dependencies
1. https://www.nuget.org/packages/Newtonsoft.Json/
2. https://www.nuget.org/packages/Selenium.Support/
3. https://www.nuget.org/packages/Selenium.WebDriver/

Then [a chrome web driver](https://www.nuget.org/packages/WebDriver.ChromeDriver.win32/) was installed, as well as [NLog] (https://www.nuget.org/packages/NLog/).

### Configuration
To get started, a new app.config was added which will contain the settings, like a base url, accounts and other settings. A static configuration class holds these values

A base class for the unit tests is used to setup the web driver and the framework:
```csharp
[TestClass]
public class TestBase
{
    [TestInitialize]
    public void TestInitialize()
    {
      AtataContext.Configure()
          .UseChrome().WithArguments("disable-extensions", "no sandbox", "start-maximized")
          .UseBaseUrl(Configuration.BaseUrl)
          .UseTestName(TestContext.TestName)
          .AddNLogLogging()
          .UseCulture("de-de")
          .AddTraceLogging()
          .Build();
    }

    [TestCleanup]
    public void TestCleanup()
    {
        AtataContext.Current.CleanUp();
    }
}
```

That's the basic setup, one can now directly start writing unit tests.

Page objects
--------------
For home a new page object has been created which can then be used for navigation etc.
```csharp
public class HomePage : Page<HomePage>
{
}
```

UI Tests
--------------
Now some tests needs to be written to test how fast one can write tests with this framework, how stable is it and what happens when some test fails.

### Using the framework in unit tests
#### Test the page title
```csharp
[TestMethod]
public void Home_ShouldHaveCorrectTitle_WhenOpened()
{
    Go.To<HomePage>().PageTitle.Should
        .Equal(
            "Amazon.de: Günstige Preise für Elektronik & Foto, Filme, Musik, Bücher, Games, Spielzeug & mehr");
}
```
#### A search input and buttons
The home pageobject was extended by the search and sort bar. At amazon the sortbar is located directly below the search and contains the amount of results and the searchTerm.
```csharp
public class HomePage : Page<_>
{
    [FindById("twotabsearchtextbox")]
    public TextInput<_> SearchBar { get; set; }

    [FindByClass("nav-input")]
    public Button<_> SearchButton { get; set; }

    public SortBar<_> SortBar { get; set; }
}
```
The sortbar is implemented as control which can contain multiple other UI components
```csharp
[ControlDefinition("div", ContainingClass = "searchTemplate", ComponentTypeName = "search template")]
public class SortBar<TPage> : Control<TPage> where TPage : PageObject<TPage>
{
    [FindById("s-result-count")]
    public H1<TPage> ResultsCount { get; set; }

    [FindByClass("a-color-state a-text-bold")]
    public Text<TPage> SearchTerm { get; set; }
}
```
The actual unit tests looks like this:
```csharp
[TestMethod]
public void SortBar_ShouldContainSearchTerm_WhenSearchIsUsedWithSearchTerm()
{
    const string searchTerm = "ui testing";

    Go.To<HomePage>().SearchBar.Set(searchTerm).SearchButton.Click()
    .SortBar.ResultsCount.Should.Not.BeNull()
    .SortBar.SearchTerm.Should.Contain(searchTerm);
}
```
#### Logging
Because of the `AddNLogLogging()` in the test initialization and the nlog config log files are automatically generated.
When all unit tests are executed in VS these logs were generated:
1. Home_ShouldHaveCorrectTitle_WhenOpened.txt
2. SortBar_ShouldContainSearchTerm_WhenSearchIsUsedWithSearchTerm.txt

The second file contains than this log:
```
2017-11-30 19:33:45.5688 INFO Starting test: SortBar_ShouldContainSearchTerm_WhenSearchIsUsedWithSearchTerm
2017-11-30 19:33:45.6278 TRACE Starting: Set up AtataContext
2017-11-30 19:33:45.6323 TRACE Set: BaseUrl=https://www.amazon.de/
2017-11-30 19:33:45.6358 TRACE Set: RetryTimeout=5.000s; RetryInterval=0.500s
2017-11-30 19:33:45.6393 TRACE Set: Culture=de-DE
2017-11-30 19:33:48.1906 TRACE Set: Driver=ChromeDriver (alias=chrome)
2017-11-30 19:33:48.1981 TRACE Finished: Set up AtataContext (2.570s)
2017-11-30 19:33:48.2681 INFO Go to "Home" page
2017-11-30 19:33:48.3416 INFO Go to URL "https://www.amazon.de/"
2017-11-30 19:33:50.6276 INFO Starting: Set "ui testing" to "Search Bar" text input
2017-11-30 19:33:52.9064 INFO Finished: Set "ui testing" to "Search Bar" text input (2.278s)
2017-11-30 19:33:52.9159 INFO Starting: Click "Search" button
2017-11-30 19:33:54.7788 INFO Finished: Click "Search" button (1.862s)
2017-11-30 19:33:54.7978 INFO Starting: Verify "Sort Bar" search template's "Results Count" <h1> heading content should not be null
2017-11-30 19:33:54.9603 INFO Finished: Verify "Sort Bar" search template's "Results Count" <h1> heading content should not be null (0.162s)
2017-11-30 19:33:54.9683 INFO Starting: Verify "Sort Bar" search template's "Search Term" element content should contain "ui testing"
2017-11-30 19:33:55.4425 INFO Finished: Verify "Sort Bar" search template's "Search Term" element content should contain "ui testing" (0.474s)
2017-11-30 19:33:55.4740 INFO Starting: Clean up test context
2017-11-30 19:33:55.6400 INFO Finished: Clean up test context (0.165s)
2017-11-30 19:33:55.6480 INFO Finished test (10.081s)
2017-11-30 19:33:55.6560 INFO Pure test execution time:  7.271s
```
