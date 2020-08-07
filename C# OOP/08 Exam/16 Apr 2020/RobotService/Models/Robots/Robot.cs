using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Robots
{
  public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;
        private string owner = "Service";

        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

        }
        public string Name { get; }

        public int Happiness
        {
            get => this.happiness;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw  new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }

        }

        public int Energy
        {
            get => this.energy;

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner
        {
            get => this.owner;
            set => this.owner = value;
        }

        public bool IsBought { get; set; } = false;
        public bool IsChipped { get; set; } = false;
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
