using NUnit.Framework;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQADroppablePage
    {
        public void AssertColorOnTargetElement(string before)
        {
            Assert.IsFalse(before == GetBackgroundColorOnTargetElement());
        }

        public void AssertTextInTargetElement(string expected)
        {
            Assert.AreEqual(expected, GetTextInTargetElement());
        }

        public void AssertTextInSourceElement(string expected)
        {
            Assert.AreEqual(expected, GetTextInSourceElement());
        }
    }
}
