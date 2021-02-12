--Problem 16. Create SoftUni Database

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL,  
)

CREATE TABLE Addresses 
(
    Id INT  PRIMARY KEY IDENTITY(1, 1),
    AddressText NVARCHAR(50) NOT NULL,
    TownId INT,
    CONSTRAINT FK_Addresses_Towns
    FOREIGN KEY (TownId)
    REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL,
)

CREATE TABLE Employees 
(
    Id INT  PRIMARY KEY IDENTITY(1, 1),
    FirstName NVARCHAR(20) NOT NULL,
    MiddleName NVARCHAR(20) NOT NULL,
    LastName NVARCHAR(20) NOT NULL,
    JobTitle NVARCHAR(20) NOT NULL,
    DepartmentId INT  FOREIGN KEY REFERENCES Departments(Id),
    HireDate DATE,
    Salary DECIMAL(9, 2) NOT NULL,
    AddressId INT FOREIGN KEY REFERENCES Addresses(Id),      
)

--Problem 17. Backup Database
BACKUP DATABASE SoftUni TO DISK='D:\test\Softuni01-backup.bak'

DROP DATABASE SoftUni

RESTORE DATABASE SoftUni FROM DISK='D:\test\Softuni01-backup.bak'

--Problem 18. Basic Insert
INSERT INTO Towns (Name) VALUES 
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments (Name) VALUES 
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)VALUES 
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)


--Problem 19. Basic Select All Fields
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees

--Problem 20. Basic Select All Fields and Order Them
SELECT * FROM Towns
ORDER BY Name

SELECT * FROM Departments
ORDER BY Name

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21. Basic Select Some Fields
SELECT Name FROM Towns
ORDER BY Name

SELECT Name FROM Departments
ORDER BY Name

SELECT FirstName,
       LastName,
       JobTitle,
       Salary
  FROM Employees
ORDER BY Salary DESC

--Problem 22. Increase Employees Salary
UPDATE Employees
   SET Salary *= 1.1

SELECT Salary
  FROM Employees

