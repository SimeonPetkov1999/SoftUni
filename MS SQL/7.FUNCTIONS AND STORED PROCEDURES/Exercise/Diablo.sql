--13.	*Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(MAX))
RETURNS Table 
AS
RETURN	
	SELECT SUM(t.Cash) AS SumCash
		FROM(SELECT 
				ug.GameId, 
				g.Name, 
				ug.Cash,
				ROW_NUMBER() OVER (PARTITION BY GameID ORDER BY GameID) AS [ROW]
			FROM UsersGames ug
			JOIN Games g ON ug.GameId=g.Id
			WHERE g.Name=@GameName) AS t
			WHERE t.ROW %2!=0	
GO

SELECT *
FROM dbo.ufn_CashInUsersGames('Love in a mist')
