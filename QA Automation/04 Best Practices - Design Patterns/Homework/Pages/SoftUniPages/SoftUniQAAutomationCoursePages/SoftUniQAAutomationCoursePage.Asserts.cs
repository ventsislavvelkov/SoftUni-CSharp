using NUnit.Framework;

namespace Homework.Pages.SoftUniPages
{
    public partial class SoftUniQAAutomationCoursePage
    {
        public void AssertQACourseHeaderText(string expected)
        {
            Assert.AreEqual(expected, QACourseHeading.Text);
        }
    }
}
