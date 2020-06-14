using NUnit.Framework;
using Homework.Pages.DemoQAPages;

namespace Homework.Tests.Interaction
{
    [TestFixture]
    public class SortableTests : BaseTest
    {
        
        private DemoQASortablePage _demoQaSortablePage;

        [SetUp]
        public void SetUp()
        {
            Initiate();

            _demoQaSortablePage = new DemoQASortablePage(Driver);
            _demoQaSortablePage.NavigateTo();
        }

        [Test]
        public void CheckNameOnFirstElement_When_Sorting()
        {
            //Arrange
            var firstElementBefore = "Two";

            //Act
            Builder.ClickAndHold(_demoQaSortablePage.FirstElement).MoveToElement(_demoQaSortablePage.SecondElement).MoveByOffset(0, 10).Release().Perform();

            //Assert
            _demoQaSortablePage.AssertNameOnFirstElement(firstElementBefore);
        }

        [Test]
        public void CheckNameOnMovedElement_When_Sorting()
        {
            //Arrange
            var movedElement = "One";

            //Act
            Builder.ClickAndHold(_demoQaSortablePage.FirstElement).MoveToElement(_demoQaSortablePage.SecondElement).MoveByOffset(0, 10).Release().Perform();


            //Assert
            _demoQaSortablePage.AssertNameOnMovedElement(movedElement);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
