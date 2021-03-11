--Section 3. Querying 

--5. Mechanic Assignments
SELECT 
	m.FirstName +' '+ m.LastName as Mechanic,
	j.Status,
	j.IssueDate
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId,j.IssueDate,j.JobId

--6. Current Clients
SELECT
	c.FirstName + ' '+c.LastName as Client,
	DATEDIFF(day,j.IssueDate,'2017-04-24') as [Days going],
	j.Status
FROM Mechanics m
	JOIN Jobs j ON m.MechanicId = j.MechanicId
	JOIN Clients c On j.ClientId = c.ClientID
WHERE j.Status !='Finished'
ORDER BY [Days Going] DESC

--7. Mechanic Performance
SELECT
	m.FirstName + ' ' + m.LastName as Mechanic,
	AVG(DATEDIFF(day,j.IssueDate,j.FinishDate)) as [Average Days]
FROM Jobs j
	JOIN Mechanics m ON j.MechanicId = m.MechanicId
GROUP BY m.FirstName + ' ' + m.LastName,m.MechanicId 
ORDER BY m.MechanicId asc

--8. Available Mechanics
SELECT  m.FirstName + ' '+m.LastName
FROM  Mechanics m
	left JOIN Jobs j ON j.MechanicId = m.MechanicId
WHERE j.JobId IS NULL OR (SELECT COUNT(JobId)
						  FROM Jobs
						  WHERE Status !='Finished' AND MechanicId=m.MechanicId
						  GROUP BY MechanicId,Status)IS NULL
GROUP BY m.MechanicId, ( m.FirstName + ' '+m.LastName)

--9. Past Expenses
SELECT j.JobId,SUM(p.Price) 
FROM Jobs j 
	Join PartsNeeded pn ON j.JobId = pn.JobId
	Join Parts p On pn.PartId = p.PartId
WHERE j.Status ='Finished'
GROUP BY j.JobId
ORDER BY SUM(p.Price) DESC,j.JobId

--10. Missing Parts

--SELECT * 
--FROM Parts p
--	LEFT JOIN OrderParts op ON p.PartId = op.PartId
--	LEFT JOIN Jobs j ON o.JobId = j.JobId
--	LEFT JOIN Orders o ON op.OrderId = o.OrderId
	
--WHERE j.Status != 'Finished'










