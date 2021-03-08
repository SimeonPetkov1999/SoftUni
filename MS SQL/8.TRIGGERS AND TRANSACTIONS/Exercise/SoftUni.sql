--8. Employees with Three Projects
CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
	BEGIN TRANSACTION
	DECLARE @NumberOfProjectsForEmployee INT = (SELECT COUNT(*) 
									 FROM EmployeesProjects 
									 WHERE EmployeeID = @emloyeeId)
	IF (@NumberOfProjectsForEmployee > 3)
		BEGIN 
			ROLLBACK;
			THROW 50001, 'The employee has too many projects!' ,1;	
		END
		
	INSERT INTO EmployeesProjects (EmployeeID,ProjectID)
	VALUES (@emloyeeId,@projectID)
COMMIT

--9. Delete Employees
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(MAX),
	LastName NVARCHAR(MAX),
	MiddleName NVARCHAR(MAX),
	JobTitle NVARCHAR(MAX),
	DepartmentId INT REFERENCES Departments(DepartmentID),
	Salary DECIMAL(10,4)
)

CREATE TRIGGER ut_SaveEmployeeInfo ON Employees 
AFTER DELETE
AS
	INSERT INTO Deleted_Employees
	SELECT 
	FirstName,
	LastName,
	MiddleName,
	JobTitle,
	DepartmentID,
	Salary
	FROM deleted
GO