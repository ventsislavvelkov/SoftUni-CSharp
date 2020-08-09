using System;
using System.Globalization;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            var msg = string.Format(ExceptionMessages.AlreadyChipped, robot.Name);

            if (robot.IsChipped)
            {
                throw  new ArgumentException(msg);
            }

            robot.Happiness -= 5;
            robot.IsChipped = true;
            robot.ProcedureTime -= procedureTime;
            this.Robots.Add(robot);
        }
    }
}