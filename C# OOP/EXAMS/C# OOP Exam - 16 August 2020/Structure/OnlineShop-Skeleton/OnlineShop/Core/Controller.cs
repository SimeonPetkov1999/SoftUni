using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            this.CheckIfComputerExists(computerId);

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!Enum.TryParse(componentType, out ComponentType type))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }
           
            IComponent component = type switch
            {
                ComponentType.CentralProcessingUnit => new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.Motherboard => new Motherboard(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.PowerSupply => new PowerSupply(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.RandomAccessMemory => new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.SolidStateDrive => new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation),
                ComponentType.VideoCard => new VideoCard(id, manufacturer, model, price, overallPerformance, generation),
            };

            this.computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(x=>x.Id==id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (Enum.TryParse(computerType, out ComputerType type)==false)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = type switch
            {
                ComputerType.DesktopComputer => new DesktopComputer(id, manufacturer, model, price),
                ComputerType.Laptop => new Laptop(id, manufacturer, model, price)
            };

            this.computers.Add(computer);
            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            this.CheckIfComputerExists(computerId);

            if (this.peripherals.Any(x => x.Id == id)) 
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (Enum.TryParse(peripheralType, out PeripheralType type) == false)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = type switch
            {
                PeripheralType.Headset => new Headset(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Keyboard => new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Monitor => new Monitor(id, manufacturer, model, price, overallPerformance, connectionType),
                PeripheralType.Mouse => new Mouse(id, manufacturer, model, price, overallPerformance, connectionType)
            };

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, peripheral.Id, computerId);
            
        }

        public string BuyBest(decimal budget)
        {
            var computerToBuy = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.Price)//
                .First();

            if (this.computers.Count == 0 || computerToBuy == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            this.computers.Remove(computerToBuy);

            return computerToBuy.ToString();
        }

        public string BuyComputer(int id)
        {
            this.CheckIfComputerExists(id);
            var computer = this.computers.FirstOrDefault(x => x.Id == id);

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            this.CheckIfComputerExists(id);
            return this.computers.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.CheckIfComputerExists(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            var component = computer.RemoveComponent(componentType);
            this.components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.CheckIfComputerExists(computerId);

            var computer = this.computers.FirstOrDefault(x => x.Id == computerId);
            var peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private void CheckIfComputerExists(int computerId)
        {
            if (this.computers.Any(x => x.Id == computerId) == false)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }
    }
}
