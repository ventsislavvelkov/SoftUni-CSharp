using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Reflection;

namespace Homework.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public void Initiate()
        {
            Driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            Driver.Manage().Window.Maximize();
            Builder = new Actions(Driver);
        }

        protected IWebDriver Driver { get; private set; }

        protected Actions Builder { get; private set; }

    }
}
