using NuGet.Frameworks;
using NUnit.Framework;

namespace Robots.Tests
{
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [Test]
        public void CheckRobotConstructor()
        {
            robot = new Robot("Robokop", 100);

            var expectedName = "Robokop";
            var expectedMaxBattery = 100;

            Assert.AreEqual(expectedName, robot.Name);
            Assert.AreEqual(expectedMaxBattery, robot.MaximumBattery);
        }

        [Test]
        public void CheckRobotManagerConstructor()
        {
            robotManager = new RobotManager(100);

            var expectedCapacity = 100;
            
            Assert.AreEqual(expectedCapacity, robotManager.Capacity);
        }

        [Test]
        public void CheckNegativeCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                robotManager = new RobotManager(-1);
            });
        }

        [Test]

        public void CheckRobotManagerCountWorkCorrectly()
        {
            robotManager = new RobotManager(5);

            robot = new Robot("Billi", 50);
           var robot2 = new Robot("Ema", 40);
           
            robotManager.Add(robot);
            robotManager.Add(robot2);

            var expectedCount = 2;

            Assert.AreEqual(robotManager.Count, expectedCount);
        }

        [Test]
        public void CheckRobotNameIfExist()
        {
            robotManager = new RobotManager(3);
            robot = new Robot("Eli", 30);
            var robot2 = new Robot("Eli", 30);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                
                robotManager.Add(robot2);
            });
        }

        [Test]
        public void CheckRobotCountNotEnougnCapacity()
        {
            robotManager = new RobotManager(2);
            robot = new Robot("Eli", 30);
            var robot2 = new Robot("Suzi", 30);
            var robot3 = new Robot("Mimi", 30);

            robotManager.Add(robot);
            robotManager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot3);
            });
        }

        [Test]
        public void CheckRobotRemoveWithNoExistRobotName()
        {
            robotManager = new RobotManager(2);
            robot = new Robot("Eli", 30);
           
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Eli");
            });
        }

        [Test]
        public void CheckRobotRemoveWorkCorrectly()
        {
            robotManager = new RobotManager(2);
            robot = new Robot("Eli", 30);
            robotManager.Add(robot);
            robotManager.Remove("Eli");
            var expectResult = 0;

            Assert.AreEqual(robotManager.Count, expectResult);
        }

        [Test]
        public void CheckWorkMethodReduceBatteryCorrect()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(2);

            robotManager.Add(robot);

            robotManager.Work("Eli", "job", 10);

            var expectedBattry = 90;

            Assert.AreEqual(expectedBattry, robot.Battery);
        }

        [Test]
        public void CheckIfRobotIsNull()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(3);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Eli", "job",110);
            });

        }

        [Test]
        public void CheckIfRobotNameExistInWork()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(3);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Mimi", "job", 10);
            });

        }

        [Test]
        public void CheckIfRobotWorkMetodWorkCorrectly()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(3);

            robotManager.Add(robot);


        }

        [Test]
        public void CheckChargeWorksCorrect()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(5);
            robotManager.Add(robot);

            robotManager.Work("Eli", "job", 60);

            robotManager.Charge("Eli");
            var expectedBattery = 100;

            Assert.AreEqual(expectedBattery, robot.Battery);
        }

        [Test]
        public void CheckWheterChargeThrowsExceptionIfRobotIsNull()
        {
            robot = new Robot("Eli", 100);
            robotManager = new RobotManager(5);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("NaNi");
            });
        }
    }
}
