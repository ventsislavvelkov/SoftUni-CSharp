using System;
using System.Dynamic;
using System.Reflection.Metadata;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);

                }

                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bulletsCount;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                this.bulletsCount = value;
            }
        }

        public abstract int Fire();

    }
}