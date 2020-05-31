using System;
using System.Collections.Immutable;
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
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(6));

            _builder = new Actions(_driver);

            //Navigate to Interactions
            var clickInteractions = _driver.FindElement(By.XPath("//h5[normalize-space(text())= 'Interactions']/ancestor::*[@class='card mt-4 top-card']"));
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
        public void FirstTestDraggable_To_Diagonal_Down()
        {
            var clickDraggableBtn = _wait.Until(d =>
                d.FindElements(By.XPath("//*[normalize-space(text())= 'Interactions']//ancestor::div[@class='element-group']//li")));

            clickDraggableBtn[4].Click();



            var draggableBox = _wait.Until(d =>
                d.FindElement(By.Id("dragBox")));

            var positionXBefore = draggableBox.Location.X;

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(draggableBox,336, 242).Perform();

            var sourcePositionXAfter = draggableBox.Location.X;

            Assert.AreNotEqual(positionXBefore, sourcePositionXAfter);
        }

        [Test]
        public void SecondTestDraggable_ToLeft_Up_Corner()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElements(By.XPath("//*[normalize-space(text())= 'Interactions']//ancestor::div[@class='element-group']//li")));

            clickDraggableBtn[4].Click();

            var draggableBox = _wait.Until(b =>
                b.FindElement(By.Id("dragBox")));

            var positionXBefore = draggableBox.Location.X;

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(draggableBox, -336, -242).Perform();

            var sourcePositionXAfter = draggableBox.Location.X;

            Assert.AreNotEqual(positionXBefore, sourcePositionXAfter);
        }

        [Test]
        public void ThirdTestDraggable_ToRight_Up_Corner()
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
        public void FirstTestDroppable_IntoTheBox()
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
        public void SecondTestDroppable_OutOfBox()
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
        public void ThirdTestDroppable_InToTheBox_CheckMessage()
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
        public void FirstTestResizable_To_Min()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElements(By.XPath("//*[normalize-space(text())= 'Interactions']//ancestor::div[@class='element-group']//li")));

            clickDraggableBtn[2].Click();

            

            var fullBox = _driver.FindElement(By.Id("resizableBoxWithRestriction"));

            var resizeArrow = _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[1]/div/span"));
            
            Thread.Sleep(500);

            _builder.DragAndDropToOffset(resizeArrow, -50, -50).Perform();


            Assert.AreEqual(150,fullBox.Size.Height);
            Assert.AreEqual(150,fullBox.Size.Width);

        }

        [Test]
        public void SecondTestResizable_To_Max()
        {


            var clickDraggableBtn = _wait.Until(d =>
                d.FindElements(By.XPath("//*[normalize-space(text())= 'Interactions']//ancestor::div[@class='element-group']//li")));

            clickDraggableBtn[2].Click();



            var fullBox = _driver.FindElement(By.Id("resizableBoxWithRestriction"));

            var resizeArrow = _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div[1]/div/span"));

            Thread.Sleep(500);

            _builder.DragAndDropToOffset(resizeArrow, 300, 100).Perform();


            Assert.AreEqual(300, fullBox.Size.Height);
            Assert.AreEqual(500, fullBox.Size.Width);

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

            var sourceBox = _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]"));

            var targetBox = _driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[5]"));

            Thread.Sleep(500);

            _builder.ClickAndHold(sourceBox).MoveToElement(targetBox).Perform();


            Assert.AreNotEqual(targetBox.Location.Y, sourceBox.Location.Y);
        }
    }
}