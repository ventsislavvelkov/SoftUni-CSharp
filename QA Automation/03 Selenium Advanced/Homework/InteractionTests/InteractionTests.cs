using System;
using System.IO;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace InteractionTests
{
    public class Tests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;
        private Actions _builder;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://demoqa.com/");
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            _builder = new Actions(_driver);

            //Navigate to Inmteractions
            var clickInteractions = _driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div/div[5]"));
            clickInteractions.Click();

            // scroll down
            var js = _driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,950)");
        }

        [TearDown]
        public void TearDown()
        {
           _driver.Quit();
        }


        [Test]
        public void FirstTestDraggable()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]")));

            clickDraggableBtn.Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.Id("dragBox")));

            var positionXBefore = draggableBox.Location.X;

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(draggableBox,336, 242).Perform();

            var sourcePositionXAfter = draggableBox.Location.X;

            Assert.AreNotEqual(positionXBefore, sourcePositionXAfter);
        }


        [Test]
        public void SecondTestDraggable()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]")));

            clickDraggableBtn.Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.Id("dragBox")));

            var positionXBefore = draggableBox.Location.X;

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(draggableBox, -336, -242).Perform();

            var sourcePositionXAfter = draggableBox.Location.X;

            Assert.AreNotEqual(positionXBefore, sourcePositionXAfter);
        }

        [Test]
        public void ThirdTestDraggable()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[5]")));

            clickDraggableBtn.Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.Id("dragBox")));

            var positionXBefore = draggableBox.Location.X;

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(draggableBox, 999, -177).Perform();

            var sourcePositionXAfter = draggableBox.Location.X;

            Assert.AreNotEqual(positionXBefore, sourcePositionXAfter);
        }



        [Test]
        public void FirstTestDroppable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[4]")));

            clickDraggableBtn.Click();

            var sourceBox = _wait.Until(d =>
                d.FindElement(By.Id("draggable")));

            var targetBox = _wait.Until(d =>
                d.FindElement(By.Id("droppable")));

            Thread.Sleep(500);

            var DroppedBackgroundColorBefore = targetBox.GetCssValue("background-color");

            _builder.DragAndDrop(sourceBox, targetBox).Perform();

            var DroppedBackgroundColorAfter = targetBox.GetCssValue("background-color");

            Assert.AreNotEqual(DroppedBackgroundColorBefore, DroppedBackgroundColorAfter);
        }

        [Test]
        public void SecondTestDroppable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[4]")));

            clickDraggableBtn.Click();

            var sourceBox = _wait.Until(d =>
                d.FindElement(By.Id("draggable")));

            var targetBox = _wait.Until(d =>
                d.FindElement(By.Id("droppable")));

            Thread.Sleep(500);

            var DroppedBackgroundColorBefore = targetBox.GetCssValue("background-color");

            _builder.DragAndDropToOffset(sourceBox, 295, 189).Perform();

            var DroppedBackgroundColorAfter = targetBox.GetCssValue("background-color");

            Assert.AreEqual(DroppedBackgroundColorBefore, DroppedBackgroundColorAfter);
        }

        [Test]
        public void ThirdTestDroppable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[4]")));

            clickDraggableBtn.Click();

            var sourceBox = _wait.Until(d =>
                d.FindElement(By.Id("draggable")));

            var targetBox = _wait.Until(d =>
                d.FindElement(By.Id("droppable")));

            Thread.Sleep(500);

            _builder.DragAndDrop(sourceBox, targetBox).Perform();

            var messageAfter = _wait.Until(m =>
                m.FindElement(By.XPath("//*[@id='droppable']/p")));

            Assert.AreEqual("Dropped!", messageAfter.Text);

        }



        [Test]
        public void FirstTestResizable()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[3]")));

            clickDraggableBtn.Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div/span")));

            var fullBox = _wait.Until(b =>
                b.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div")));

            var height = fullBox.Size.Height + 150;

            Thread.Sleep(500);


           _builder.ClickAndHold(draggableBox).MoveByOffset(250,150).Perform();

           Assert.AreEqual(height,fullBox.Size.Height);

        }

        [Test]
        public void SecondTestResizable()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[3]")));

            clickDraggableBtn.Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div/span")));

            var fullBox = _wait.Until(b =>
                b.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[2]/div")));

            var width = fullBox.Size.Width + 250;

            Thread.Sleep(500);


            _builder.ClickAndHold(draggableBox).MoveByOffset(250, 150).Perform();

            Assert.AreEqual(width, fullBox.Size.Width);

        }


        [Test]
        public void FirstTestSelectable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[2]")));

            clickDraggableBtn.Click();

            var box = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]")));


            Thread.Sleep(500);

            var DroppedBackgroundColorBefore = box.GetCssValue("background-color");

            _builder.Click(box).Perform();

            var DroppedBackgroundColorAfter = box.GetCssValue("background-color");

            Assert.AreNotEqual(DroppedBackgroundColorBefore, DroppedBackgroundColorAfter);
        }

        [Test]
        public void SecondTestSelectable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[2]")));

            clickDraggableBtn.Click();

            var box = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]")));


            Thread.Sleep(500);

            var DroppedBackgroundColorBefore = box.GetCssValue("background-color");

            _builder.DoubleClick(box).Perform();

            var DroppedBackgroundColorAfter = box.GetCssValue("background-color");

            Assert.AreNotSame(DroppedBackgroundColorBefore, DroppedBackgroundColorAfter);
        }


        [Test]
        public void FirstTestSortable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[1]")));

            clickDraggableBtn.Click();

            var sourceBox = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

            var targetBox = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[5]")));

            Thread.Sleep(500);

            var positionBefore = sourceBox.Location.Y;

            _builder.ClickAndHold(sourceBox).MoveToElement(targetBox).Perform();


            Assert.AreEqual(positionBefore, sourceBox.Location.Y);
        }

        [Test]
        public void SecondTestSortable()
        {

            var clickDraggableBtn = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div/div[5]/div/ul/li[1]")));

            clickDraggableBtn.Click();

            var sourceBox = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]")));

            var targetBox = _wait.Until(d =>
                d.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[5]")));

            Thread.Sleep(500);

            _builder.ClickAndHold(sourceBox).MoveToElement(targetBox).Perform();


            Assert.AreNotEqual(targetBox.Location.Y, sourceBox.Location.Y);
        }
    }
}