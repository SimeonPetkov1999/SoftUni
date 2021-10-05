Create database People
Use People

Create table People
(
	Id int Primary Key Identity,
	[Name] Nvarchar(200) Not null,
	Picture VARBINARY,
	Height decimal(20,2),
	[Weight] decimal(20,2),
	Gender Char(1),
	Birthdate Date Not null,
	Biography Nvarchar(Max)
)

Insert Into People([Name],Height,[Weight],Gender,Birthdate,Biography)
Values('Petar',200,100,'m','05/11/1999','testtest'),
('Petar',200,100,'m','05/11/1999','testtest'),
('Petar',200,100,'m','05/11/1999','testtest'),
('Petar',200,100,'m','05/11/1999','testtest'),
('Petar',200,100,'m','05/11/1999','testtest')

Create Table Users(
	Id int Primary Key Identity,
	Username varchar(30) not null,
	[Password] varchar(26), 
	ProfilePicture varbinary,
	LastLoginTime Date,
	IsDeleted Bit
)

Insert into Users(Username,[Password],LastLoginTime,IsDeleted)
values('Simo','122343','10/10/2021',0),
('Simo','122343','10/10/2021',0),
('Simo','122343','10/10/2021',0),
('Simo','122343','10/10/2021',0),
('Simo','122343','10/10/2021',0)