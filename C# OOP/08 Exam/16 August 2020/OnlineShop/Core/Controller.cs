using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> AllComputers = new List<IComputer>();
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            switch (computerType)
            {
                case "DesktopComputer":
                    var desktop = new DesktopComputer(id, manufacturer, model, price);

                    if (AllComputers.Any(i => i.Id == desktop.Id))
                    {
                        throw new ArgumentException("Computer with this id already exists.");
                    }
                    AllComputers.Add(desktop);
                    break;
                case "Laptop":
                    var laptop = new Laptop(id, manufacturer, model, price);

                    if (AllComputers.Any(i => i.Id == laptop.Id))
                    {
                        throw new ArgumentException("Computer with this id already exists.");
                    }
                    AllComputers.Add(laptop);
                    break;
                default:
                    throw new ArgumentException("Computer type is invalid.");
            }

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            var computer = CheckComputerIfExists(computerId);
            if (computer.Peripherals.Any(i => i.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral newPeripheral;
            switch (peripheralType)
            {
                case "Headset":
                    newPeripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);

                    break;
                case "Keyboard":
                    newPeripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);

                    break;
                case "Monitor":
                    newPeripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);

                    break;
                case "Mouse":
                    newPeripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    ;
                    break;
                default:
                    throw new ArgumentException("Peripheral type is invalid.");
            }
            computer.AddPeripheral(newPeripheral);
            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = AllComputers.FirstOrDefault(i => i.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
            var peripheral = computer.RemovePeripheral(peripheralType);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            var computer = CheckComputerIfExists(computerId);
            if (computer.Components.Any(i => i.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }
            IComponent newComponent;
            switch (componentType)
            {
                case "CentralProcessingUnit":
                    newComponent = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "Motherboard":
                    newComponent = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "PowerSupply":
                    newComponent = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "RandomAccessMemory":
                    newComponent = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "SolidStateDrive":
                    newComponent = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                case "VideoCard":
                    newComponent = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    break;
                default:
                    throw new ArgumentException("Component type is invalid.");
            }

            computer.AddComponent(newComponent);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = CheckComputerIfExists(computerId);

            var component = computer.RemoveComponent(componentType);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string BuyComputer(int id)
        {
            var computer = CheckComputerIfExists(id);
            AllComputers.Remove(computer);
            return computer.ToString();

        }

        public string BuyBest(decimal budget)
        {
            var colection = AllComputers;
            foreach (var computer in AllComputers)
            {
                if (computer.Price > budget)
                {
                    colection.Remove(computer);
                }
            }

            if (colection.Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            colection.OrderBy(i => i.OverallPerformance);
            var bestComputer = colection.FirstOrDefault();
            AllComputers.Remove(bestComputer);
            return bestComputer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = CheckComputerIfExists(id);
            return computer.ToString();
        }

        public IComputer CheckComputerIfExists(int id)
        {
            var computer = AllComputers.FirstOrDefault(i => i.Id == id);
            if (computer == null)
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computer;
        }
    }
}
