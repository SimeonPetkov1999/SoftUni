using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private List<IProcedure> procedures;

        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new List<IProcedure>() 
            {
                new Charge(),
                new Chip(),
                new Polish(),
                new Rest(),
                new TechCheck(),
                new Work(),
            };
        }

        public string Charge(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var chargeProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(Charge));
            chargeProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var chipProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(Chip));

            chipProcedure.DoService(robot, procedureTime);

            return string.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            var procedure = this.procedures.FirstOrDefault(x => x.GetType().Name == procedureType);
            return procedure.History().TrimEnd();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return string.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var polishProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(Polish));
            polishProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var restProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(Rest));
            restProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            var robot = GetRobot(robotName);
            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var techCheckProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(TechCheck));
            techCheckProcedure.DoService(robot,procedureTime);
            return string.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            var robot = GetRobot(robotName);
            var workProcedure = this.procedures.FirstOrDefault(x => x.GetType().Name == nameof(Work));
            workProcedure.DoService(robot, procedureTime);
            return string.Format(OutputMessages.WorkProcedure, robotName,procedureTime);
        }

        private IRobot GetRobot(string robotName)
        {
            if (this.garage.Robots.ContainsKey(robotName) == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            return this.garage.Robots[robotName];

        }
    }
}
