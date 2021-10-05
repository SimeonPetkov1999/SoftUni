Create Database Movies
Use Movies

Create Table Directors(
	Id int Primary key identity,
	DirectorName Nvarchar(50),
	Notes Nvarchar(500),
)

Create Table Genres(
	Id int Primary key identity,
	GenreName Nvarchar(50),
	Notes Nvarchar(500),
)

Create Table Categories(
	Id int Primary key identity,
	CategoryName Nvarchar(50),
	Notes Nvarchar(500),
)

Create Table Movies(
	Id int Primary key identity,
	Title Nvarchar(50),
	DirectorId int References Directors(Id),
	CopyrightYear int,
	Lenght int,
	GenreId int References Genres(Id),
	CategoryId int References Categories(Id),
	Rating int,
	Notes Nvarchar(300)
)

insert into Directors(DirectorName,Notes)
Values('Ivan','testtest'),
('Gosho','testtest'),
('Petar','testtest'),
('Misho','testtest'),
('Simo','testtest')

insert into Genres(GenreName,Notes)
Values('Horror','test'),
('SciFi','test'),
('Mystery','test'),
('Adventure','test'),
('Comedy','test')

insert into Categories(CategoryName,Notes)
values('test1','test'),
('test2','test'),
('test3','test'),
('test4','test'),
('test5','test')

insert into Movies(Title,DirectorId,CopyrightYear,Lenght,GenreId,CategoryId,Rating,Notes)
values('test',1,2012,120,1,2,10,'test'),
('test',1,2012,120,1,2,10,'test'),
('test',1,2012,120,1,2,10,'test'),
('test',1,2012,120,1,2,10,'test'),
('test',1,2012,120,1,2,10,'test')

