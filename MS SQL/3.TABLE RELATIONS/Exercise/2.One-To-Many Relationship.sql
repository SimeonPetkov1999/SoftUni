CREATE DATABASE Models
USE Models

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(25) NOT NULL,
	EstablishedOn DATE
)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(25) NOT NULL,
	ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers([Name],EstablishedOn) VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966')

INSERT INTO Models([Name],ManufacturerID) VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Niva',3)



