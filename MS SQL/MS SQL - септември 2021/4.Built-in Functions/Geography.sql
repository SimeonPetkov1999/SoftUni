--12. Countries Holding 'A'
SELECT C.CountryName,C.IsoCode 
FROM Countries C 
WHERE C.CountryName LIKE '%A%A%A%'
ORDER BY C.IsoCode

--13. Mix of Peak and River Names
SELECT PeakName,RiverName,
LOWER(PeakName+Right(RiverName,LEN(RiverName)-1)) AS Mix
FROM Rivers,Peaks
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
ORDER BY Mix

