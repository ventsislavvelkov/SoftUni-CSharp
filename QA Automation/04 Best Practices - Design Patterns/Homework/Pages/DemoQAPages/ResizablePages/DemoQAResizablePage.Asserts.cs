using NUnit.Framework;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQAResizablePage
    {
        public void AssertElementHeight(string before)
        {
            Assert.IsFalse(before == GetHeightOnResizableElement());
        }

        public void AssertElementWidth(string expected)
        {
            Assert.IsFalse(expected == GetWidthOnResizableElement());
        }
    }
}
