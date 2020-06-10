using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Homework.Pages.Selenium
{
   public  class HomePage :BasePage
    {
        public HomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public string CurrentUrl => Driver.Url;

        public string Title => Driver.Title;
    }
}
