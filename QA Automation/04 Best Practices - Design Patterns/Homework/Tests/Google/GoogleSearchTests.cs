using NUnit.Framework;
using OpenQA.Selenium;
using Homework.Pages.GooglePages;
using Homework.Pages.SeleniumPages;

namespace Homework.Tests.Google
{
    [TestFixture]
    public class GoogleSearchTests : BaseTest
    {
        private GoogleHomePage _googleHomePage;
        private GoogleSeleniumSearchResultsPage _googleSearchResultPage;
        private SeleniumHomePage _seleniumHomePage;

        [SetUp]
        public void Setup()
        {
            Initiate();
            _googleHomePage = new GoogleHomePage(Driver);
            _googleHomePage.NavigateTo();
            _googleSearchResultPage = new GoogleSeleniumSearchResultsPage(Driver);
            _seleniumHomePage = new SeleniumHomePage(Driver);
        }

        [Test]
        public void FirstUrlAddress_When_SearchForSelenium()
        {
            //Arrange
            var expectedUrl = "https://www.selenium.dev/";

            //Act
            _googleHomePage.SearchField.SendKeys("Selenium");
            _googleHomePage.SearchField.SendKeys(Keys.Return);
            _googleSearchResultPage.Results[0].Click();

            //Assert
            _seleniumHomePage.AssertUrlAddress(expectedUrl);
        }

        [Test]
        public void SeleniumHomePageTitle_When_OpenFromGoogleSearch()
        {
            //Arrange
            var expectedTitle = "SeleniumHQ Browser Automation";

            //Act
            _seleniumHomePage.NavigateTo();

            //Assert
            _seleniumHomePage.AssertHomePageTitle(expectedTitle);
        }

        [TearDown]
        public void TearDown()
        {
           Driver.Quit();
        }
    }
}
