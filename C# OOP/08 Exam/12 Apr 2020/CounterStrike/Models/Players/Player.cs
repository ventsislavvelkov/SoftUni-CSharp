using System;
using System.Collections.Generic;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private bool isAlive;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;

        }

        public string Username
        {
            get => this.username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }

        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get => this.armor;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public IGun Gun
        {
            get => this.gun;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public bool IsAlive
        {
            get => this.isAlive;
            set
            {
                if (health < 0)
                {
                    this.isAlive = true;
                }

            }
        }
        public void TakeDamage(int points)
        {
            if (this.Armor > 0)
            {
                if (this.Armor >= points)
                {
                    this.Armor -= points;
                    points = 0;
                }
                else
                {
                    points -= this.Armor;
                    this.Armor = 0;
                }

                if (points > 0)
                {
                    if (this.Health <= points)
                    {
                        this.Health = 0;
                    }
                    else
                    {
                        this.Health -= points;
                    }
                }
            }
        }
    }
}