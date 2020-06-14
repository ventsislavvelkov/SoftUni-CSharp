using NUnit.Framework;

namespace Homework.Pages.SeleniumPages
{
    public partial class SeleniumHomePage
    {
       public void AssertUrlAddress(string expectedUrl)
        {
            Assert.AreEqual(expectedUrl, CurrentUrl);
        }

        public void AssertHomePageTitle(string expectedTitle)
        {
            Assert.AreEqual(expectedTitle, Title);
        }
    }
}
