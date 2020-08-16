using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                double avarage = 0;
                if (Components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    foreach (var component in components)
                    {
                        avarage += component.OverallPerformance;
                    }

                    avarage /= components.Count;
                    return avarage + base.OverallPerformance;
                }
            }
        }

        public override decimal Price
        {
            get
            {
                decimal sumAllParts = 0;
                foreach (var peripheral in Peripherals)
                {
                    sumAllParts += peripheral.Price;
                }

                foreach (var component in Components)
                {
                    sumAllParts += component.Price;
                }
                return base.Price + sumAllParts;
            }
        }

        public IReadOnlyCollection<IComponent> Components
        {
            get => components.AsReadOnly();
        }
        public IReadOnlyCollection<IPeripheral> Peripherals
        {
            get => peripherals.AsReadOnly();
        }
        public void AddComponent(IComponent component)
        {
            if (components.Contains(component))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = Components.FirstOrDefault(i => i.GetType().Name == componentType);
            if (!components.Contains(component))
            {
                throw new ArgumentException($"Component {componentType} does not exist in {GetType().Name} with Id {Id}.");
            }
            components.Remove(component);
            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Contains(peripheral))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {GetType().Name} with Id {Id}.");
            }
            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var periperal = peripherals.FirstOrDefault(i => i.GetType().Name == peripheralType);
            if (!peripherals.Contains(periperal))
            {
                throw new ArgumentException(
                    $"Peripheral {peripheralType} does not exist in {GetType().Name} with Id {Id}.");
            }
            peripherals.Remove(periperal);
            return periperal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            sb.AppendLine($" Components ({Components.Count}):");
            foreach (var component in Components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            double averageOverallPerformancePeripherals = 0;
            foreach (var peripheral in Peripherals)
            {
                averageOverallPerformancePeripherals += peripheral.OverallPerformance;
            }

            averageOverallPerformancePeripherals /= Peripherals.Count;
            sb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({averageOverallPerformancePeripherals:F2}):");
            foreach (var peripheral in Peripherals)
            {
                sb.AppendLine("  " + peripheral.ToString());
            }
            return sb.ToString().TrimEnd();
        }


    }
}
