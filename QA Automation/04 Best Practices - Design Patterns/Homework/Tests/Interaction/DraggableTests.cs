using NUnit.Framework;
using Homework.Pages.DemoQAPages;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Tests.Interaction
{
    public class DraggableTests : BaseTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQaStaticElements _demoQaStaticElements;
        private DemoQADraggablePage _demoQaDraggablePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaHomePage.NavigateTo();
            _demoQaHomePage.MenuInteractionButton.Click();
            _demoQaStaticElements = new DemoQaStaticElements(Driver);
            _demoQaStaticElements.SubMenu("Dragabble").Click();
            _demoQaDraggablePage = new DemoQADraggablePage(Driver);
        }

        [Test]
        public void CheckSourceElementVerticalPosition_When_DraggingHorizontal()
        {
            //Arrange
            var draggableElementVerticalPositionBefore = _demoQaDraggablePage.GetDraggableElementVerticalPosition();

            //Act
            Builder.DragAndDropToOffset(_demoQaDraggablePage.DragElement, 150, 0).Perform();

            //Assert
            _demoQaDraggablePage.AssertElementVerticalPosition(draggableElementVerticalPositionBefore);
        }

        [Test]
        public void CheckSourceElementHorizontalPosition_When_DraggingVertical()
        {
            //Arrange
            var draggableElementHorizontalPositionBefore = _demoQaDraggablePage.GetDraggableElementHorizontalPosition();

            //Act
            Builder.DragAndDropToOffset(_demoQaDraggablePage.DragElement, 0, 250).Perform();

            //Assert
            _demoQaDraggablePage.AssertElementHorizontalPosition(draggableElementHorizontalPositionBefore);
        }

        [Test]
        public void CheckSourceElementVerticalAndHorizontalPosition_When_DraggingDiagonal()
        {
            //Arrange
            var draggableElementVerticalPositionBefore = _demoQaDraggablePage.GetDraggableElementVerticalPosition();
            var draggableElementHorizontalPositionBefore = _demoQaDraggablePage.GetDraggableElementHorizontalPosition();

            //Act
            Builder.DragAndDropToOffset(_demoQaDraggablePage.DragElement, 350, 400).Perform();

            //Assert
            _demoQaDraggablePage.AssertElementVerticalAndHorizontalPosition(draggableElementVerticalPositionBefore, draggableElementHorizontalPositionBefore);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
