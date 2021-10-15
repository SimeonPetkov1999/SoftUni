--01. Employees with Salary Above 35000
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT E.FirstName,E.LastName
	FROM Employees E 
	WHERE E.Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber @NUMBER DECIMAL(18,4) 
AS
BEGIN
	SELECT E.FirstName,E.LastName
	FROM Employees E 
	WHERE E.Salary >= @NUMBER
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith @ToStart VARCHAR(MAX)
AS
BEGIN
	SELECT T.Name 
	FROM Towns T
	WHERE T.Name LIKE @ToStart + '%'
END

EXEC usp_GetTownsStartingWith 'B'

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown @TOWN VARCHAR(MAX)
AS
BEGIN
	SELECT E.FirstName,E.LastName 
	FROM Employees E 
	JOIN Addresses A ON E.AddressID = A.AddressID
	JOIN Towns T ON A.TownID = T.TownID
	WHERE T.Name = @TOWN
END

EXEC usp_GetEmployeesFromTown 'SOFIA'

--05. Salary Level Function
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


SELECT Salary,dbo.ufn_GetSalaryLevel(Salary)
FROM Employees

--06. Employees by Salary Level
CREATE PROCEDURE usp_EmployeesBySalaryLevel @LEVEL VARCHAR(MAX)
AS
BEGIN
	SELECT E.FirstName,E.LastName AS [SalaryLevel]
	FROM Employees E
	WHERE DBO.ufn_GetSalaryLevel(SALARY) = @LEVEL	
END

--07. Define Function
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
