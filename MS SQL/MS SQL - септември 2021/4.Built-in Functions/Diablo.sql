--14. Games From 2011 and 2012 Year
SELECT TOP(50) Name,FORMAT(Start, 'yyyy-MM-dd')AS Start
FROM Games 
WHERE YEAR(Start)>= 2011 AND YEAR(Start) <= 2012
ORDER BY Start,Name

--15. User Email Providers
SELECT Username,SUBSTRING(Email, CHARINDEX('@', Email)+1,LEN(Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider],Username

--16. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17. Show All Games with Duration
SELECT Name,
CASE
    WHEN DATEPART(HOUR,Start) >= 0 AND DATEPART(HOUR,Start) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR,Start) >= 12 AND DATEPART(HOUR,Start) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR,Start) >= 18 AND DATEPART(HOUR,Start) < 24 THEN 'Evening'
END AS [Part of Day],
CASE
    WHEN Duration <=3 THEN 'Extra Short'
	WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY Name,Duration,[Part of Day]

--18. Orders Table

SELECT ProductName, OrderDate,DATEADD(DAY, 3, OrderDate),DATEADD(MONTH, 1, OrderDate)  
FROM Orders