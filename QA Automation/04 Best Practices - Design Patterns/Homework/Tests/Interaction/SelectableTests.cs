using NUnit.Framework;
using Homework.Pages.DemoQAPages;

namespace Homework.Tests.Interaction
{
    [TestFixture]
   public class SelectableTests : BaseTest
    {
        private DemoQASelectablePage _demoQaSelectablePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _demoQaSelectablePage = new DemoQASelectablePage(Driver);
            _demoQaSelectablePage.NavigateTo();
        }

        [Test]
        public void CheckColorOnFirstElement_When_Selected()
        {
            //Arrange
            string colorOnFirstElementBefore = _demoQaSelectablePage.GetBackgroundColorOnFirstElement();

            //Act
            Builder.Click(_demoQaSelectablePage.FirstElement).Perform();

            //Assert
            _demoQaSelectablePage.AssertColorOnFirstElement(colorOnFirstElementBefore);
        }

        [Test]
        public void CheckColorOnFirstAndSecondElement_When_SelectedFirst()
        {
            //Arrange
            var backGroundColorOnSecondElement = _demoQaSelectablePage.GetBackgroundColorOnSecondElement();

            //Act
            Builder.Click(_demoQaSelectablePage.FirstElement).Perform();

            //Assert
            _demoQaSelectablePage.AssertColorOnFirstAndSecondElement(backGroundColorOnSecondElement);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
