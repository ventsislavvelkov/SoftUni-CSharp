using NUnit.Framework;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQADraggablePage : DemoQaStaticElements
    {
        public void AssertElementVerticalPosition(string before)
        {
            Assert.IsFalse(before == GetDraggableElementVerticalPosition());
        }

        public void AssertElementHorizontalPosition(string before)
        {
            Assert.IsFalse(before == GetDraggableElementHorizontalPosition());
        }

        public void AssertElementVerticalAndHorizontalPosition(string verticalPositionBefore, string horizontalPositionBefore)
        {
            Assert.IsTrue(verticalPositionBefore != GetDraggableElementVerticalPosition() &&
                horizontalPositionBefore != GetDraggableElementHorizontalPosition());
        }
    }
}
