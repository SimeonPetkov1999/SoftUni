CREATE DATABASE Students 

CREATE TABLE Students
(
	StudentID INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY(StudentID,ExamID)
)

INSERT INTO Students([Name]) VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO Exams([Name]) VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO StudentsExams VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103)

SELECT Students.Name,Exams.Name AS Exam
FROM StudentsExams 
JOIN Students ON Students.StudentID = StudentsExams.StudentID
JOIN Exams ON Exams.ExamID = StudentsExams.ExamID
