using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;
        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.robots.ContainsKey(robot.Name))
            {
                throw  new ArgumentException(ExceptionMessages.ExistingRobot, robot.Name);
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(ExceptionMessages.InexistingRobot, robotName);
            }

            IRobot robot = this.robots[robotName];

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}