using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ExerciseAdoNet
{
    class Program
    {
        private const string connectionString = @"Server =.;Database=MinionsDB;Integrated Security = true";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var countryName = Console.ReadLine();
            var setUpperCaseQuery = @"UPDATE Towns
                                      SET Name = UPPER(Name)
                                      WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
            var getTownsQuery = @"SELECT t.Name 
                                  FROM Towns as t
                                  JOIN Countries AS c ON c.Id = t.CountryCode
                                  WHERE c.Name = @countryName";

            using var command = new SqlCommand(setUpperCaseQuery, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            var towns = new List<string>();

            var changedTowns = command.ExecuteNonQuery() as int?;

            if (changedTowns == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                using var commandTowns = new SqlCommand(getTownsQuery, connection);
                commandTowns.Parameters.AddWithValue("@countryName", countryName);
                var reader = commandTowns.ExecuteReader();
                while (reader.Read())
                {
                    towns.Add(reader[0] as string);
                }

                Console.WriteLine($"{towns.Count} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }


        }

        private static SqlCommand MinionsNames(SqlConnection connection)
        {
            var vilianId = Console.ReadLine();
            var vilianQuery = @"SELECT Name FROM Villains WHERE Id = @Id";
            var getVilianNameCommand = new SqlCommand(vilianQuery, connection);
            getVilianNameCommand.Parameters.AddWithValue("@Id", vilianId);

            var vilianName = getVilianNameCommand.ExecuteScalar();

            if (vilianName == null)
            {
                Console.WriteLine($"No villain with ID {vilianId} exists in the database.");
            }
            else
            {
                var minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                var getNumberOfMinionsCommand = new SqlCommand(minionsQuery, connection);
                getNumberOfMinionsCommand.Parameters.AddWithValue(@"Id", vilianId);
                var numberOfMinions = getNumberOfMinionsCommand.ExecuteReader();

                Console.WriteLine($"Villain: {vilianName}");
                if (!numberOfMinions.HasRows)
                {
                    Console.WriteLine($"(no minions)");
                }
                else
                {
                    while (numberOfMinions.Read())
                    {
                        Console.WriteLine($"{numberOfMinions[0]}. {numberOfMinions[1]} {numberOfMinions[2]}");
                    }
                }
            }

            return getVilianNameCommand;
        }

        private static void GetViliansNames(SqlConnection connection)
        {
            var query = @"SELECT 
                                v.Name, 
                                COUNT(mv.VillainId) AS MinionsCount
                          FROM Villains AS v
                          JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                          GROUP BY v.Id, v.Name
                          HAVING COUNT(mv.VillainId) > 2
                          ORDER BY COUNT(mv.VillainId)";

            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} - {reader[1]}");
            }
        }

        private static void InitialSetup(SqlConnection connection)
        {
            //CREATE DATABASE
            var command = new SqlCommand("CREATE DATABASE MinionsDB", connection);
            command.ExecuteNonQuery();

            //CREATE TABLES
            var queries = GetCreateQueries();
            SqlCommand createCommand = null;
            foreach (var query in queries)
            {
                createCommand = new SqlCommand(query, connection);
                createCommand.ExecuteNonQuery();
            }

            //INSERT DATA
            var insertQueries = GetInsertQueries();
            SqlCommand insertCommand = null;
            foreach (var query in insertQueries)
            {
                insertCommand = new SqlCommand(query, connection);
                insertCommand.ExecuteNonQuery();
            }
        }

        private static string[] GetInsertQueries()
        {
            return new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };
        }

        private static string[] GetCreateQueries()
        {
            return new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };
        }

        private static void DemoMethod()
        {
            var connectionString = @"Server =.;Database=SoftUni;Integrated Security = true";
            var connection = new SqlConnection(connectionString);

            connection.Open();
            var command = new SqlCommand("Select Count(*) from Employees", connection);
            var readerCommand = new SqlCommand("Select FirstName,LastName from Employees", connection);

            var reader = readerCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }

        }
    }
}
