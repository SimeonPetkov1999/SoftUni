--Problem 1. Create Database
CREATE DATABASE Minions
USE Minions

--Problem 2. Create Tables
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
	Age INT,
)

CREATE TABLE Town
(
	Id INT PRIMARY KEY,
	Name VARCHAR(50)
)

--Problem 3. Alter Minions Table
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownID) REFERENCES Town(Id);

--Problem 4. Insert Records in Both Tables
INSERT INTO Town VALUES 
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions VALUES 
	(1, 'Kevin',22 , 1),
	(2, 'Bob',15 , 3),
	(3, 'Steward',NULL , 2)

--Problem 5. Truncate Table Minions
TRUNCATE TABLE Minions

--Problem 6. Drop All Tables
DROP TABLE Minions
DROP TABLE Town

