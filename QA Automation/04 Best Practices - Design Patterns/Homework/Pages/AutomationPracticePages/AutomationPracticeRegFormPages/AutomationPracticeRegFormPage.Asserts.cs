using NUnit.Framework;

namespace Homework.Pages.AutomationPracticePages
{
    public partial class AutomationPracticeRegFormPage
    {
        public void AssertValidateEmail(string expected)
        {
            Assert.AreEqual(expected, ValidateMailInRegForm(expected));
        }

        public void AssertErrorMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(expectedErrorMessage, GetErrorMessage());
        }
    }
}
