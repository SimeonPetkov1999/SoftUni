--12. Highest Peaks in Bulgaria
SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains m ON mc.MountainId = m.Id
	JOIN Peaks p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation>2835
ORDER BY p.Elevation DESC

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM Mountains m
	JOIN Peaks p ON p.MountainId = m.Id
	JOIN MountainsCountries mc ON mc.MountainId = m.Id	
WHERE mc.CountryCode = 'BG' AND p.Elevation>2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT mc.CountryCode,COUNT(*)
FROM Mountains m
JOIN MountainsCountries mc ON mc.MountainId = m.Id
WHERE mc.CountryCode IN('RU','BG','US')
GROUP BY mc.CountryCode

--14. Countries with Rivers
SELECT TOP(5) c.CountryName,r.RiverName
FROM Countries c
FULL JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers r ON cr.RiverId = r.Id
WHERE ContinentCode = 'AF' OR ContinentCode is NULL
ORDER BY c.CountryName 

--16. Countries Without Any Mountains
SELECT 
COUNT(*) AS [Count]
FROM (SELECT 
	CountryName
	FROM Countries c
	LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
	WHERE mc.CountryCode IS NULL ) 
AS CountryWithoutMountains

--17.Highest Peak and Longest River By Country
SELECT TOP (5) c.CountryName,
MAX(p.Elevation) AS HighestPeakElevation,
MAX(r.[Length]) AS LongestRiverLength
FROM Countries c
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.MountainId
	LEFT JOIN Peaks p ON p.MountainId = mc.MountainId
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC,c.CountryName ASC


