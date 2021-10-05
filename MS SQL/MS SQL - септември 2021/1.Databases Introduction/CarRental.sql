Create database CarRental
use CarRental

Create table Categories(
	Id Int Primary key identity,
	CategoryName Nvarchar(100),
	DailyRate int,
	WeeklyRate int,
	MontlyRate int,
	WeekendRate int,
)

Create table Cars(
	Id int Primary key identity,
	PlateNumber nvarchar(20),
	Manufacturer nvarchar(50),
	Model nvarchar(50),
	CarYear int,
	CategoryId Int References Categories(Id),
	Doors int,
	Picture varbinary,
	Condition nvarchar(50),
	Available bit,
)

Create table Employees(
	Id int Primary Key identity,
	FirstName nvarchar(20),
	LastName nvarchar(20),
	Title nvarchar(15),
	Notes nvarchar(500),
)

Create table Customers(
	Id int Primary key identity,
	DriverLicenseNumber nvarchar(100),
	FullName Nvarchar(100),
	[Address] Nvarchar(100),
	City Nvarchar(50),
	ZipCode nvarchar(10),
	Notes Nvarchar(500),
)

Create table RentalOrders(
	Id int Primary Key identity,
	EmployeeId int References Employees(Id),
	CustomerId int References Customers(Id),
	CarId int References Cars(Id),
	TankLevel int,
	KilometrageStart int,
	KilometrageEnd Int,
	TotalKilometrage Int,
	StartDate Date,
	EndDate Date,
	TotalDays int,
	RateApplied int,
	TaxRate decimal(10,2),
	OrderStatus nvarchar(50),
	Notes nvarchar(500)
)

INSERT INTO Categories (CategoryName,DailyRate,WeeklyRate,MontlyRate,WeekendRate) VALUES
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

INSERT INTO Customers (DriverLicenseNumber, FullName, [Address], City, ZIPCode, Notes) VALUES 
('123456789', 'Gogo Gogov', 'testtest', 'testtest', 1233, 'testtest driver'),
('347645231', 'Mara Mareva', 'testtest', 'testtest', 5678, 'testtest driver'),
('123574322', 'Strahil Strahilov', 'testtest', 'testtest', 5689, 'Good driver')

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, StartDate, EndDate)  VALUES 
(1, 1, 1, 54, 2189, 2456, '2020-1-22', '2020-1-22'),
(2, 2, 2, 22, 13565, 14258, '2020-3-3', '2020-3-3'),
(3, 3, 3, 180, 1202, 1964, '2020-2-2', '2020-2-2')