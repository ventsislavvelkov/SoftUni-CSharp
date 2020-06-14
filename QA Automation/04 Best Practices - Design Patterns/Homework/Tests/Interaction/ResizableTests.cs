using NUnit.Framework;
using Homework.Pages.DemoQAPages;

namespace Homework.Tests.Interaction
{
    [TestFixture]
    public class ResizableTests : BaseTest
    {

        private DemoQAResizablePage _demoQaResizebalePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _demoQaResizebalePage = new DemoQAResizablePage(Driver);
            _demoQaResizebalePage.NavigateTo();
        }

        [Test]
        public void CheckElementHeight_When_Resize()
        {
            //Arrange
            var heightOnElementBefore = _demoQaResizebalePage.GetHeightOnResizableElement();

            //Act
            Builder.ClickAndHold(_demoQaResizebalePage.ResizableHandler).MoveByOffset(0, 100).Release().Perform();

            //Assert
            _demoQaResizebalePage.AssertElementHeight(heightOnElementBefore);
        }

        [Test]
        public void CheckElementWidth_When_Resize()
        {
            //Arrange
            var widthOnElementBefore = _demoQaResizebalePage.GetWidthOnResizableElement();

            //Act
            Builder.ClickAndHold(_demoQaResizebalePage.ResizableHandler).MoveByOffset(100, 0).Release().Perform();

            //Assert
            _demoQaResizebalePage.AssertElementWidth(widthOnElementBefore);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
