CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    CategoryName NVARCHAR(50) NOT NULL,
    DailyRate DECIMAL(9, 2),
    WeekLyRate DECIMAL(9, 2),
    MonthlyRate DECIMAL(9, 2),
    WeekendRate DECIMAL(9, 2),    
)

CREATE TABLE Cars 
(
    Id INT  PRIMARY KEY IDENTITY(1, 1),
    PlateNumber NVARCHAR(10) NOT NULL,
    Manufacturer NVARCHAR(20) NOT NULL,
    Model NVARCHAR(20) NOT NULL,
    CarYear INT NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
    Doors INT NOT NULL,
    Picture VARBINARY(MAX),
    Condition NVARCHAR(MAX),
    Available BIT NOT NULL,    
)

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
    Id INT  PRIMARY KEY IDENTITY(1, 1),
    DriverLicenseNumber INT NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Adress NVARCHAR(100) NOT NULL,
    City NVARCHAR(50) NOT NULL,
    ZIPCode INT NOT NULL,
    Notes NVARCHAR(MAX),   
)

CREATE TABLE RentalOrders 
(
    Id INT PRIMARY KEY IDENTITY(1, 1),
    EmployeeId INT  FOREIGN KEY REFERENCES Employees(Id),
    CustomerId INT,
    CarId INT FOREIGN KEY REFERENCES Cars(Id),
    TankLevel INT NOT NULL,
    KilometrageStart INT NOT NULL,
    KilometrageEnd INT NOT NULL,
    TotalKilometrage AS KilometrageEnd - KilometrageStart,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
    RateApplied DECIMAL(9, 2),
    TaxRate DECIMAL(9, 2),
    OrderStatus NVARCHAR(50),
    Notes NVARCHAR(MAX),       
    
    CONSTRAINT FK_RentalOrders_Customers
    FOREIGN KEY (CustomerId)
    REFERENCES Customers(Id),
)

INSERT INTO Categories (CategoryName, DailyRate, WeekLyRate, MonthlyRate, WeekendRate) VALUES
('Car', 20, 120, 500, 50.50),
('Bus', 250, 1600, 6000, 150.99),
('Truck', 500, 3000, 11900, 250.90)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('1asdddasda', 'Audi', 'CX-5', 2016, 1, 5, 123456, 'testtest', 1),
('asgadfasda', 'Mercedes', 'Tourismo', 2017, 2, 3, 99999, 'testtest', 1),
('asasdas456', 'VW', 'TGX', 2016, 3, 2, 123456, 'testtest', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES 
('Styan', 'Ivanov', 'Seller', 'testtest'),
('Martin', 'Petkov', 'Seller', 'testtest'),
('Ivan', 'Petrov', 'Manager', 'testtest')

INSERT INTO Customers (DriverLicenseNumber, FullName, Adress, City, ZIPCode, Notes) VALUES 
(123456789, 'Gogo Gogov', 'testtest', 'testtest', 1233, 'testtest driver'),
(347645231, 'Mara Mareva', 'testtest', 'testtest', 5678, 'testtest driver'),
(123574322, 'Strahil Strahilov', 'testtest', 'testtest', 5689, 'Good driver')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate)  VALUES 
(1, 1, 1, 54, 2189, 2456, '2020-1-22', '2020-1-22'),
(2, 2, 2, 22, 13565, 14258, '2020-3-3', '2020-3-3'),
(3, 3, 3, 180, 1202, 1964, '2020-2-2', '2020-2-2')