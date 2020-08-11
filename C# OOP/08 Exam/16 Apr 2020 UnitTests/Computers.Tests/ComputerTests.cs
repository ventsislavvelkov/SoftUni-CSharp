using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    using NUnit.Framework;

    public class ComputerTests
    { 
       private Part part;
       private Computer computer;

        [SetUp]
        public void Setup()
        {
            Part part = new Part("Cable", 9.50m);
            Computer computer = new Computer("Hp");

        }

        [Test]
        public void CheckPastsConstructorWorkCorrectly()
        {
            Part part = new Part("Cable", 9.50m);

            var expectedName = "Cable";
            var expectedPrice = 9.50m;

            Assert.AreEqual(expectedName, part.Name);
            Assert.AreEqual(expectedPrice, part.Price);

        }

        [Test]
        public void CheckComputerConstructorWorkCorrectly()
        {
            Computer computer = new Computer("Hp");

            var expectedName = "Hp";
            
            Assert.AreEqual(expectedName, computer.Name);

        }

        [Test]
        public void ChackArgumentNullExceptionAddEmptyComputer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(" ");
            });

        }


        [Test]
        public void CheckPartsCounterOfComputer()
        {
            computer = new Computer("Xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("monitor", 100);
            computer.AddPart(part);
            computer.AddPart(part2);

            var expectedCount = 2;

            Assert.AreEqual(expectedCount, computer.Parts.Count);

        }

        [Test]
        public void CheckIfWeCanAddEmptyPartsInComputer()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                computer = new Computer("Xiomi");
                Part part = null;

                computer.AddPart(part);
            });

        }

        [Test]
        [TestCase(null)]
        [TestCase("   ")]
        public void CheckComputerName(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                computer = new Computer(name);
            });

        }
        [Test]
        public void CheckTotalPriceOfComputerPriceWorkCorrectly()
        {
            computer = new Computer("Xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("monitor", 100);
            computer.AddPart(part);
            computer.AddPart(part2);

            var expectedPrice = 110;

            Assert.AreEqual(expectedPrice, computer.TotalPrice);

        }
        [Test]
        public void CheckRemoveWorksProperly()
        {
            computer = new Computer("xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("mouse2", 10m);
            var part3 = new Part("mouse3", 10m);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            var expectedCount = 2;

            Assert.IsTrue(computer.RemovePart(part3));
            Assert.AreEqual(expectedCount, computer.Parts.Count);
        }
        [Test]
        public void CheckWheterGetPartWorksProperly()
        {
            computer = new Computer("xiomi");
            part = new Part("mouse", 10m);
            var part2 = new Part("mouse2", 10m);
            var part3 = new Part("mouse3", 10m);

            computer.AddPart(part);
            computer.AddPart(part2);
            computer.AddPart(part3);

            var currentPart = computer.GetPart("mouse");

            Assert.AreEqual(part, currentPart);
        }

    }
}