using NUnit.Framework;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASortablePage
    {
        public void AssertNameOnFirstElement(string before)
        {
            Assert.AreEqual(before, GetTextOnFirstElement());
        }

        public void AssertNameOnMovedElement(string movedElement)
        {
            Assert.AreEqual(movedElement, GetTextOnSecondElement());
        }
    }
}
