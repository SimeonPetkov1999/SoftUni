Create Table Minions
(
	Id INT Primary key,
	[Name] Varchar(100),
	Age Int,
	TownId Int References Towns(Id)
)

Create Table Towns
(
	Id INT Primary key,
	[Name] Varchar(100),
)
--04. Insert Records in Both Tables
Insert into Towns(Id,[Name]) 
Values (1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')

Insert into Minions(Id,[Name],Age,TownId)
Values(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',null,2)

truncate table minions
drop table Minions
drop table Towns

