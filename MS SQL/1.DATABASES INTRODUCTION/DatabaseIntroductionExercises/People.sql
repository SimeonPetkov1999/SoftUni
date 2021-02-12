CREATE DATABASE People
USE People

--Problem 7. Create Table People
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(20,2),
	[Weight] DECIMAL(20,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO  People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) VALUES 
('SIMO','ASDDASDASD',1.75,80,'M','11-5-1999','ASDASDASD'),
('PESHO','DSD',1.50,55,'M','11-5-2000','ASDASDASD'),
('IVAN','ASDDD',1.95,66,'M','11-5-2015','ASDASDASD'),
('PETKAN','ASDDA',1.11,34,'M','11-5-2004','ASDASDASD'),
('MISHO','DDSDDS',1.87,78,'M','11-5-2005','ASDASDASD')

--Problem 8. Create Table Users
CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY(1,1),
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATE,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('SIMO', '12345', NULL, '1989-11-24 16:30:10', 0),
('PESHO', '12445', NULL, '1989-11-24 16:30:11', 0),
('IVAN', '12545', NULL, '1989-11-24 16:30:12', 1),
('PETKAN', '12645', NULL, '1989-11-24 16:30:13', 0),
('MISHO', '12745', NULL, '1989-11-24 16:30:14', 1)

--Problem 9. Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07C359E4B5

ALTER TABLE Users
ADD CONSTRAINT ID_Username_Key PRIMARY KEY (Id,Username)

--Problem 10. Add Check Constraint
ALTER TABLE Users
ADD CHECK (LEN(Password)>4)

--Problem 11. Set Default Value of a Field
ALTER TABLE Users
ADD CONSTRAINT defaultTime
DEFAULT GETDATE() FOR LastLoginTime;

--Problem 12. Set Unique Field
ALTER TABLE  users
ADD UNIQUE (username)

