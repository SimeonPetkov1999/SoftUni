using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }
        public void Run()
        {

            while (true)
            {
                var inputArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var command = inputArgs[0];
                var output = string.Empty;
                try
                {
                    if (command == "AddPlayer")
                    {
                        var playerType = inputArgs[1];
                        var playerUsername = inputArgs[2];
                        output= managerController.AddPlayer(playerType, playerUsername);

                    }
                    else if (command == "AddCard")
                    {
                        var cardType = inputArgs[1];
                        var cardName = inputArgs[2];
                        output = managerController.AddCard(cardType, cardName);

                    }
                    else if (command == "AddPlayerCard")
                    {
                        var username = inputArgs[1];
                        var cardName = inputArgs[2];
                        output = managerController.AddPlayerCard(username, cardName);

                    }
                    else if (command == $"Fight")
                    {
                        var attackUser = inputArgs[1];
                        var enemyUser = inputArgs[2];
                        output = managerController.Fight(attackUser, enemyUser);

                    }
                    else if (command == "Report")
                    {
                        output = managerController.Report();
                        break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                writer.WriteLine(output);
            }
        }
    }
}
