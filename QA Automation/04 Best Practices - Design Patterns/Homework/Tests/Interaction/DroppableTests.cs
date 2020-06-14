using NUnit.Framework;
using Homework.Pages.DemoQAPages;

namespace Homework.Tests.Interaction
{
    [TestFixture]
    public class DroppableTests : BaseTest
    {
        private DemoQADroppablePage _demoQaDroppablePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _demoQaDroppablePage = new DemoQADroppablePage(Driver);
            _demoQaDroppablePage.NavigateTo();
        }

        [Test]
        public void CheckColorOnTargetElement_When_DragAndDrop()
        {
            //Arrange
            var backgroundColorTargetElementBefore = _demoQaDroppablePage.GetBackgroundColorOnTargetElement();

            //Act
            Builder.DragAndDrop(_demoQaDroppablePage.DragElement, _demoQaDroppablePage.DropElement).Perform();

            //Assert
            _demoQaDroppablePage.AssertColorOnTargetElement(backgroundColorTargetElementBefore);
        }

        [Test]
        public void CheckTextInTargetElement_When_DragAndDrop()
        {
            //Arrange
            var expectedResult = "Dropped!";

            //Act
            Builder.DragAndDrop(_demoQaDroppablePage.DragElement, _demoQaDroppablePage.DropElement).Perform();

            //Assert
            _demoQaDroppablePage.AssertTextInTargetElement(expectedResult);
        }

        [Test]
        public void CheckTextInSourceElement_When_DragAndDrop()
        {
            var expectedResult = "Drag me";

            Builder.DragAndDrop(_demoQaDroppablePage.DragElement, _demoQaDroppablePage.DropElement).Perform();

            _demoQaDroppablePage.AssertTextInSourceElement(expectedResult);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
