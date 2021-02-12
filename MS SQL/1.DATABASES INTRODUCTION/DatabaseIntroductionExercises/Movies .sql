CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
    Id INT PRIMARY KEY IDENTITY ,
    DirectorName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY,
    GenereName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Categories 
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)

CREATE TABLE Movies
(
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(50),
    DirectorId INT,
    CopyrightYear  INT,
    [Length] INT,
    GenreId INT,
    CatgoryId INT,
    Rating INT, 
    Notes NVARCHAR(MAX)
)

INSERT INTO Directors(DirectorName,Notes)VALUES 
('Pesho', 'TESTTEST'), 
('Mitko','TESTTEST'),
('IVAN', 'TESTTEST'),
('GOSHO', 'TESTTEST'),
('simo', 'TESTTEST')

INSERT INTO Genres (GenereName, Notes)VALUES 
('Asen', 'TESTTEST'),
('Kaloqn', ' TESTTEST'),
('Simeon', 'TESTTEST'),
('Boris', 'TESTTEST'),
('Крум', 'TESTTEST')

INSERT INTO Categories (CategoryName,Notes)VALUES 
('HISTORY', 'TESTTEST'),
('Action', 'TESTTEST'),
('History','TESTTEST'),
('drama', 'TESTTEST' ),
('Triller', 'TESTTEST')

INSERT INTO Movies (Title,DirectorId,CopyrightYear,[Length],GenreId,CatgoryId,Rating,Notes)VALUES
(' TESTTEST' ,5,1999,78,1,5,10,'otlichen'),
('TESTTEST',4,2000,12,2,2,9,'otlichen'),
('TESTTEST',3,1980,33,3,3,5,'otlichen'),
('TESTTEST',2,1830,222,4,1,10,'iopkll'),
('TESTTEST',1,1990,120,5,1,10,'plpppp')