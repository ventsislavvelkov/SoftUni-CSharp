using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public abstract class Procedure : IProcedure
   {
       private List<IRobot> robots;

       public Procedure()
       {
           this.robots = new List<IRobot>();
       }

       public IList<IRobot> Robots => this.robots;

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}");

            foreach (IRobot robot in this.Robots)
            {
                sb.AppendLine($"{robot}");
            }

            return sb.ToString().TrimEnd();
        }

        public void DoService(IRobot robot, int procedureTime)
        {
            
        }
    }
}
