using NUnit.Framework;
using Homework.Pages.SoftUniPages;

namespace Homework.Tests.SoftUni
{
    [TestFixture]
    public class SoftUniQaAutomationTest : BaseTest
    {
        private SoftUniHomePage _softUniHomePage;
        private SoftUniQACoursePage _softUniQaCoursePage;
        private SoftUniQAAutomationCoursePage _softUniAutomationCoursePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _softUniHomePage = new SoftUniHomePage(Driver);
            _softUniHomePage.NavigateTo();
            _softUniQaCoursePage = new SoftUniQACoursePage(Driver);
            _softUniAutomationCoursePage = new SoftUniQAAutomationCoursePage(Driver);
        }

        [Test]
        public void QACourseHeaderText_When_CoursePageLoaded()
        {
            //Arrange
            var expected = "QA Automation - май 2020";

            //Act
            _softUniHomePage.MenuTrainingButton.Click();
            _softUniHomePage.ActiveCourses[1].Click();
            _softUniHomePage.MenuQACourseButton.Click();
            _softUniQaCoursePage.QACourseAutomationButton.Click();

            //Assert
            _softUniAutomationCoursePage.AssertQACourseHeaderText(expected);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

    }
}
