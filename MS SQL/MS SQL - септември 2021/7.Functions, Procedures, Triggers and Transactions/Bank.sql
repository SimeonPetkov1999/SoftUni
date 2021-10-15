--09. Find Full Name
CREATE PROCEDURE usp_GetHoldersFullName 
AS
BEGIN
	SELECT AH.FirstName + ' ' + AH.LastName AS [FULL NAME] 
	FROM AccountHolders AH
END

--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan @NUM DECIMAL(18,4)
AS
BEGIN
	SELECT AH.FirstName,AH.LastName
	FROM Accounts A
	JOIN AccountHolders AH ON A.AccountHolderId = AH.Id
	GROUP BY AH.FirstName,AH.LastName
	HAVING SUM(A.Balance) >@NUM
	ORDER BY AH.FirstName,AH.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 50000

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue(@SUM DECIMAL(18,4),@YearlyInterest FLOAT,@Years INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	DECLARE @RESULT DECIMAL(18,4)
	SET @RESULT = @SUM*(POWER((1 + @YearlyInterest),@Years))
	RETURN @RESULT
END

SELECT DBO.ufn_CalculateFutureValue(1000,10,5) AS RES

--12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount @AccountId INT, @Rate FLOAT
AS
BEGIN
	SELECT A.Id,AH.FirstName,AH.LastName,A.Balance,DBO.ufn_CalculateFutureValue(A.Balance,@Rate,5)
	FROM AccountHolders AH
	JOIN Accounts A ON AH.Id = A.AccountHolderId
	WHERE A.Id = @AccountId

END