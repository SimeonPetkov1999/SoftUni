CREATE DATABASE People

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101,1) PRIMARY KEY,
	PassportNumber CHAR(8) 
)

CREATE TABLE Person
(
	 PersonID INT IDENTITY PRIMARY KEY,
	 FirstName NVARCHAR(50) NOT NULL,
	 Salary DECIMAL NOT NULL,
	 PasportID INT UNIQUE REFERENCES Passports(PassportID) 
)

INSERT INTO Person(FirstName,Salary,PasportID) VALUES
('Robero',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101)

INSERT INTO Passports(PassportNumber) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')



