using OpenQA.Selenium;
using Homework.Pages.DemoQAPages.DemoQAPage;

namespace Homework.Pages.DemoQAPages
{
    public partial class DemoQASortablePage : DemoQaStaticElements
    {
        public DemoQASortablePage(IWebDriver driver)
            : base(driver)
        {

        }

        public override string Url => "http://www.demoqa.com/sortable";

        public string GetTextOnFirstElement()
        {
            return FirstElement.Text;
        }

        public string GetTextOnSecondElement()
        {
            return SecondElement.Text;
        }
    }
}
