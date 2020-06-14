using NUnit.Framework;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASelectablePage
    {
        public void AssertColorOnFirstElement(string before)
        {
            Assert.IsTrue(before != GetBackgroundColorOnFirstElement());
        }

        public void AssertColorOnFirstAndSecondElement(string colorSecondElement)
        {
            Assert.IsFalse(colorSecondElement == GetBackgroundColorOnFirstElement());
        }
    }
}
