--1. Employee Address
SELECT TOP(5) e.EmployeeID,e.JobTitle,e.AddressID,a.AddressID 
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY e.AddressID 

--2. Addresses with Towns
SELECT TOP(50) e.FirstName,e.LastName,t.Name AS Town,a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName,e.LastName

--3. Sales Employee
SELECT e.EmployeeID,e.FirstName,e.LastName,d.Name AS DepartmentName 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--4. Employee Departments
SELECT TOP(5) e.EmployeeID,e.FirstName,e.Salary,d.Name AS DepartmentName 
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary>15000
ORDER BY d.DepartmentID

--5. Employees Without Project
SELECT TOP(3) e.EmployeeID,e.FirstName
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID =ep.EmployeeID
WHERE ep.ProjectID is NULL
ORDER BY e.EmployeeID

--6. Employees Hired After
SELECT e.FirstName,e.LastName,e.HireDate,d.Name AS DeptName
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate>'1999-1-1' AND (d.Name IN('Sales','Finance'))
ORDER BY e.HireDate

--7. Employees with Project
SELECT TOP(5) e.EmployeeID,e.FirstName,p.Name
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8. Employee 24
SELECT e.EmployeeID,e.FirstName, IIF(p.StartDate>='2005',NULL,p.Name)--p.Name AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

SELECT e.EmployeeID,e.FirstName,
CASE
	WHEN YEAR(P.StartDate) >= 2005 THEN NULL
	ELSE p.Name
END AS [ProjectName]
FROM [Employees] e
JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--9. Employee Manager
SELECT e.EmployeeID,e.FirstName,e.ManagerID,m.FirstName AS ManagerName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE m.EmployeeID = 3 OR  m.EmployeeID = 7
ORDER BY e.EmployeeID

--10. Employee Summary
SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName,' ',e.LastName) AS EmployeeName,
	CONCAT(m.FirstName,' ',m.LastName) AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIn Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT TOP(1) AVG(E.Salary) AS MinAverageSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY MinAverageSalary


