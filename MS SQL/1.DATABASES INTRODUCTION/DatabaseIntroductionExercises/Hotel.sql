CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX),
)

CREATE TABLE Customers 
(
    AccountNumber INT PRIMARY KEY IDENTITY(1, 1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    EmergencyName NVARCHAR(50),
    EmergencyNumber NVARCHAR(20) NOT NULL,
    Notes NVARCHAR(MAX),
)

CREATE TABLE RoomStatus 
(
    RoomStatus NVARCHAR(50) PRIMARY KEY NOT NULL,
    Notes NVARCHAR(MAX),
)

CREATE TABLE RoomTypes 
(
    RoomType NVARCHAR(50)PRIMARY KEY NOT NULL,
    Notes NVARCHAR(MAX),
)

CREATE TABLE BedTypes 
(
    BedType NVARCHAR(50) PRIMARY KEY NOT NULL,
    Notes NVARCHAR(MAX),
)

CREATE TABLE Rooms 
(
    RoomNumber INT PRIMARY KEY IDENTITY(1, 1),
    RoomType NVARCHAR(50)FOREIGN KEY REFERENCES RoomTypes(RoomType),
    BedType NVARCHAR(50)FOREIGN KEY REFERENCES BedTypes(BedType),
    Rate DECIMAL(9, 2),
    RoomStatus NVARCHAR(50)  FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
    Notes NVARCHAR(MAX),
)

CREATE TABLE Payments 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    PaymentDate DATE NOT NULL,
    AccountNumber INT  FOREIGN KEY REFERENCES Customers(AccountNumber),
    FirstDateOccupied DATE NOT NULL,
    LastDateOccupied DATE NOT NULL,
    TotalDays AS DATEDIFF(Day, FirstDateOccupied, LastDateOccupied),
    AmountCharged DECIMAL(9, 2) NOT NULL,
    TaxRate DECIMAL(9, 2),
    TaxAmount DECIMAL(9, 2),
    PaymentTotal DECIMAL(9, 2),
    Notes NVARCHAR(MAX),
)

CREATE TABLE Occupancies 
(
    Id INT  PRIMARY KEY IDENTITY(1, 1),
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    DateOccupied DATE,
    AccountNumber INT  FOREIGN KEY REFERENCES Customers(AccountNumber),
    RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
    RateApplied DECIMAL(9, 2) NOT NULL,
    PhoneCharge DECIMAL(9, 2),
    Notes NVARCHAR(MAX),
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES 
('JustTest', 'JustTest', 'JustTest', 'JustTest'),
('JustTest', 'JustTest', 'JustTest', 'JustTest'),
('JustTest', 'JustTest', 'JustTest', 'JustTest')

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyNumber) VALUES 
('JustTest', 'JustTest', '9999999999', '123'),
('JustTest', 'JustTest', '8888888888', '123'),
('JustTest', 'JustTest', '7777777777', '123')

INSERT INTO RoomStatus (RoomStatus, Notes) VALUES 
('Clean', 'JustTest'),
('Dirty', 'JustTest'),
 ('Repair', 'JustTest')

INSERT INTO RoomTypes (RoomType, Notes) VALUES 
('Small', 'JustTest'),
('Medium', 'JustTest'),
('Large', 'JustTest')

INSERT INTO BedTypes (BedType)VALUES 
('Normal'),
('Comfort'),
('VIP')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus)VALUES 
('Small', 'Normal', 50, 'Dirty'),
('Medium', 'Comfort', 70, 'Clean'),
('Large', 'VIP', 100, 'Repair')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, AmountCharged, TaxRate)VALUES 
(1, '2020-05-06', 1, '2019-06-18', '2020-07-03', 1256.33, 166.23),
(2, '2020-10-11', 2, '2019-10-12', '2020-10-22', 556, 125.95),
(3, '2020-10-26', 3, '2019-11-09', '2020-11-11', 146.74, 100)

INSERT INTO Occupancies (EmployeeId, AccountNumber, RoomNumber, RateApplied)VALUES 
(1, 1, 1, 55.55),
(2, 2, 2, 44.44),
(3, 3, 3, 33.33)

--Problem 23. Decrease Tax Rate
UPDATE Payments
   SET TaxRate -= TaxRate * 0.03

SELECT TaxRate
  FROM Payments

--Problem 24. Delete All Records
TRUNCATE TABLE Occupancies