--01. One-To-One Relationship

Create table Passports(
	PassportId int primary key identity,
	PassportNumber nvarchar(50)
)

create table Persons(
	PersonId int primary key identity,
	FirstName nvarchar(50),
	Salary Decimal(9,2),
	PassportID int unique references Passports(PassportId)
)

--02. One-To-Many Relationship
Create table Manufacturers(
	Id int primary key identity,
	[Name] nvarchar(20),
	EstablishedOn Date
)

Create Table Models(
	Id int primary key identity,
	[Name] nvarchar(50),
	ManufacturerID int references Manufacturers(Id)
)

--03. Many-To-Many Relationship

Create table Students(
	Id int primary key identity,
	[Name] nvarchar(50)
)

create table Exams(
	Id int primary key identity,
	[Name] nvarchar(50)
)

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(ID),
	ExamID INT REFERENCES Exams(ID),
	PRIMARY KEY(StudentID,ExamID)
)

--04. Self-Referencing
Create table Teachers(
	TeacherId int primary key identity(101,1),
	[Name] nvarchar(50),
	ManagerId int References Teachers(TeacherId)
)

--05. Online Store Database
create database Store

create table Cities(
	CityId int primary key identity,
	[Name] varchar(50)
)

create table ItemsTypes(
	ItemTypeId int primary key identity,
	[Name] varchar(50)
)

create table items(
	ItemId int primary key identity,
	[Name] varchar(50),
	ItemTypeId int foreign key references ItemsTypes(ItemTypeId)
)

create table Customers(
	CustomerId int Primary key identity,
	[Name] varchar(50),
	Birthdate Date,
	CityId int Foreign key references Cities(CityId)
)

Create table Orders(
	OrderId int primary key identity,
	CustomerId int foreign key references Customers(CustomerId)
)

create table OrderItems(
	OrderId int foreign key References Orders(orderId),
	ItemId int foreign key References Items(itemId),
	primary key(OrderId,itemId)
)

--06. University Database

Create table Majors(
	MajorId int Primary key Identity,
	[Name] varchar(50),
)

Create table Students(
	StudentId int primary key identity,
	StudentNumber int,
	StudentName varchar(50),
	MajorId int foreign key references Majors(MajorId)
)

Create table Subjects(
	SubjectId int primary key identity,
	SubjectName varchar(50)
)

create table Agenda(
	StudentId int Foreign key references Students(StudentId) not null,
	SubjectId int Foreign key references Subjects(SubjectId) not null
	Primary key(StudentId,SubjectId)
)

create table Payments(
	PaymentId int primary key identity,
	PaymentDate Date,
	PaymentAmount Decimal(9,2),
	StudentId int Foreign key references Students(StudentId)
)

--09. *Peaks in Rila
select m.MountainRange,p.PeakName,p.Elevation from Peaks p
left join Mountains m on p.MountainId = m.Id
where m.MountainRange = 'Rila'
order by Elevation desc

