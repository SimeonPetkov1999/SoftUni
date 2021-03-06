--9. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName,' ',LastName) as FullName 
	FROM AccountHolders
GO

EXEC usp_GetHoldersFullName

--10. People with Balance Higher Than

CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan (@Number INT)
AS
	SELECT TotalMoney.FirstName,TotalMoney.LastName
	FROM(
		SELECT ah.FirstName,ah.LastName,SUM(a.Balance) as [SUM]--,a.AccountHolderId,a.Balance 
		FROM AccountHolders ah
		JOIN Accounts a ON ah.Id = a.AccountHolderId
		GROUP BY ah.FirstName,ah.LastName) as TotalMoney
	WHERE TotalMoney.SUM>@Number
	ORDER BY TotalMoney.FirstName,TotalMoney.LastName

	--SELECT FirstName, LastName 
	--FROM Accounts AS a
	--JOIN AccountHolders ah ON a.AccountHolderId = ah.Id
	--GROUP BY FirstName, LastName
	--HAVING SUM(Balance) > @Number
	--ORDER BY FirstName, LastName
GO

EXEC usp_GetHoldersWithBalanceHigherThan 50000

--11. Future Value Function
CREATE OR ALTER FUNCTION dbo.ufn_CalculateFutureValue(@SUM DECIMAL(18,4), @YearlyRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @Value DECIMAL(18,4)
	SET @Value = @SUM * POWER((1 + @YearlyRate),@NumberOfYears)
	RETURN @VALUE
END

SELECT dbo.ufn_CalculateFutureValue(1000,0.1,5)

--12. Calculating Interest
CREATE OR Alter PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
	SELECT 
		ah.Id AS 'Account Id',
		ah.FirstName AS 'First Name',
		ah.LastName AS 'Last Name',
		a.Balance as 'Current Balance',
		dbo.ufn_CalculateFutureValue(a.Balance,@InterestRate,5) AS 'Balance in 5 years'
	FROM AccountHolders ah
	JOIN Accounts a ON ah.Id = a.AccountHolderId
	WHERE ah.Id = @AccountId
GO

EXEC usp_CalculateFutureValueForAccount 1,0.1
