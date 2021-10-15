--12. Highest Peaks in Bulgaria
SELECT C.CountryCode ,M.MountainRange,P.PeakName,P.Elevation
FROM Countries C
JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
JOIN Mountains M ON MC.MountainId = M.Id
JOIN Peaks P ON M.Id = P.MountainId
WHERE C.CountryCode = 'BG' AND P.Elevation>2835
ORDER BY P.Elevation DESC

--13. Count Mountain Ranges
SELECT MC.CountryCode, COUNT(C.CountryCode)
FROM Countries C
JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
JOIN Mountains M ON MC.MountainId = M.Id
WHERE C.CountryCode IN('BG','RU','US')
GROUP BY MC.CountryCode

--14. Countries With or Without Rivers
SELECT TOP(5) C.CountryName, R.RiverName 
FROM Countries C
LEFT JOIN CountriesRivers CR ON C.CountryCode = CR.CountryCode
LEFT JOIN Rivers R ON CR.RiverId = R.Id
WHERE C.ContinentCode = 'AF'
ORDER BY C.CountryName

--16. Countries Without any Mountains
SELECT COUNT(*) 
FROM Countries C
LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
WHERE MC.CountryCode IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP(5) C.CountryName, MAX(P.Elevation) HighestPeakElevation ,MAX(R.Length) LongestRiverLength
FROM Countries C
LEFT JOIN MountainsCountries MC ON C.CountryCode = MC.CountryCode
LEFT JOIN Mountains M ON MC.MountainId = M.Id
LEFT JOIN Peaks P ON M.Id = P.MountainId
LEFT JOIN CountriesRivers CR ON C.CountryCode = CR.CountryCode
LEFT JOIN Rivers R ON CR.RiverId = R.Id
GROUP BY C.CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC,CountryName

