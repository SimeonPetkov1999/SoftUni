--1. Employees with Salary Above 35000
CREATE PROC dbo.usp_GetEmployeesSalaryAbove35000 
AS
	SELECT FirstName,LastName
	FROM Employees
	WHERE Salary>35000
GO

EXEC usp_GetEmployeesSalaryAbove35000

--2. Employees with Salary Above Number
CREATE OR ALTER PROC dbo.usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
	SELECT FirstName,LastName
	FROM Employees
	WHERE Salary>@Number
GO

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 48100

--3. Town Names Starting With
CREATE PROC dbo.usp_GetTownsStartingWith(@StartingString NVARCHAR(MAX)) 
AS
	SELECT [Name] 
	FROM Towns
	WHERE [Name] LIKE @StartingString+'%'
GO

EXEC dbo.usp_GetTownsStartingWith 'b'

--4. Employees from Town
CREATE PROC dbo.usp_GetEmployeesFromTown(@TownName NVARCHAR(MAX)) 
AS
	SELECT FirstName,LastName
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.Name = @TownName
GO

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'

--5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4)) 
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @Output NVARCHAR(MAX)
	IF(@Salary<30000)
		SET @Output = 'Low'
	ELSE IF(@Salary <=50000)
		SET @Output ='Average'
	ELSE 
		SET @Output ='High'
	
	RETURN @Output
END

SELECT dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

--6. Employees by Salary Level

CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel NVARCHAR(MAX))
AS
	SELECT FirstName,LastName
	FROM Employees e
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
GO

EXEC usp_EmployeesBySalaryLevel 'High'

--7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(MAX), @word NVARCHAR(MAX))
RETURNS BIT 
AS
BEGIN
	DECLARE @CurrentIndex INT = 1
	
	WHILE(@CurrentIndex<=LEN(@word))		
		BEGIN 
			DECLARE @currentLetter varchar(1) = SUBSTRING(@word, @CurrentIndex, 1);
			IF(CHARINDEX(@currentLetter, @setOfLetters)) = 0
				RETURN 0;
			ELSE
			SET @currentIndex += 1;
		END

	RETURN 1
END

--8. * Delete Employees and Departments
