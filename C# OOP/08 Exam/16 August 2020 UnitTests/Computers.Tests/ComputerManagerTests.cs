using System;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        
        private Computer computer;
        private ComputerManager cm;

        private string manufacturer = "Apple";
        private string model = "New";
        private decimal price = 1005.55m;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckComputerManagerConstructorWorkCorrectly()
        {
             computer = new Computer(manufacturer, model, price);
             cm = new ComputerManager();

            cm.AddComputer(computer);

            var expectedResult = 1;

            Assert.AreEqual(cm.Count, expectedResult);
        }


        [Test]
        public void CheckComputerManagerComputerNameIfExists()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                 computer = new Computer(manufacturer, model, price);
                Computer computer2 = new Computer(manufacturer, model, price);
                 cm = new ComputerManager();

                cm.AddComputer(computer);
                cm.AddComputer(computer2);
            });
        }

        [Test]
        public void CheckComputerManagerRemoveComputerCorrectly()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                 computer = new Computer(manufacturer, model, price);
                Computer computer2 = new Computer("Toshiba", model, price);
                Computer computer3 = new Computer("HP", model, price);
                 cm = new ComputerManager();

                cm.AddComputer(computer);
                cm.AddComputer(computer2);
                cm.AddComputer(computer3);
                cm.RemoveComputer("Toshiba", "New");
                cm.RemoveComputer("Hp", "New");
            });
        }

        [Test]
        public void CheckComputerManagerGetComputerCorrectly()
        {
             computer = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer("Toshiba", model, price);
            Computer computer3 = new Computer("HP", model, price);
             cm = new ComputerManager();

            cm.AddComputer(computer);
            cm.AddComputer(computer2);
            cm.AddComputer(computer3);

            var getComputer = cm.GetComputer(manufacturer, model);

            var expectedManufacturer = "Apple";
            var expectedModel = "New";

          
              Assert.AreEqual(getComputer.Model, expectedModel );
              Assert.AreEqual(getComputer.Manufacturer, expectedManufacturer);

        }


        [Test]
        public void CheckComputerManagerGetComputerIfIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                 computer = new Computer(manufacturer, model, price);
                Computer computer2 = new Computer("Toshiba", model, price);
                 cm = new ComputerManager();

                cm.AddComputer(computer);
                cm.AddComputer(computer2);

                cm.GetComputer("Solo", "Line");

            });
        }

        [Test]
        public void CheckComputerManagerGetComputerByManufacturer()
        {
             computer = new Computer(manufacturer, model, price);
            Computer computer2 = new Computer("Toshiba", model, price);
             cm = new ComputerManager();

            cm.AddComputer(computer);
            cm.AddComputer(computer2);

            var getComputerByManufacturer = cm.GetComputersByManufacturer("Toshiba");


            Assert.AreEqual(getComputerByManufacturer.Count, 1 );

        }


        [Test]
        public void CheckComputerManagerIsValidNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                 computer = new Computer(manufacturer, model, price);
                Computer computer2 =  null;
                 cm = new ComputerManager();

                cm.AddComputer(computer);
                cm.AddComputer(computer2);

            });
        }
    }
}