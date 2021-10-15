--01. Employee Address
SELECT TOP(5) E.EmployeeID,E.JobTitle,E.AddressID,A.AddressText 
FROM Employees E
JOIN Addresses A ON E.AddressID = A.AddressID 
ORDER BY AddressID

--02. Addresses with Towns
SELECT TOP(50) E.FirstName,E.LastName,T.Name,A.AddressText 
FROM Employees E
JOIN Addresses A ON E.AddressID = A.AddressID
JOIN Towns T ON A.TownID = T.TownID
ORDER BY FirstName,LastName

--03. Sales Employees
SELECT E.EmployeeID,E.FirstName,E.LastName,D.Name 
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE D.Name = 'Sales'
ORDER BY E.EmployeeID

--04. Employee Departments
SELECT TOP(5) E.EmployeeID,E.FirstName,E.Salary,D.Name 
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE E.Salary>15000
ORDER BY D.DepartmentID

--05. Employees Without Projects
SELECT TOP(3)  E.EmployeeID,E.FirstName 
FROM Projects P
RIGHT JOIN EmployeesProjects EP ON P.ProjectID = EP.ProjectID
RIGHT JOIN Employees E ON EP.EmployeeID = E.EmployeeID
WHERE EP.ProjectID IS NULL
ORDER BY E.EmployeeID

--06. Employees Hired After
SELECT E.FirstName,E.LastName,E.HireDate,D.Name
FROM Employees E
JOIN Departments D ON E.DepartmentID = D.DepartmentID
WHERE E.HireDate>'1.1.1999' AND (D.Name = 'Sales' OR D.Name = 'Finance')
ORDER BY E.HireDate

--07. Employees With Project
SELECT TOP(5) E.EmployeeID,E.FirstName,P.Name 
FROM Projects P
JOIN EmployeesProjects EP ON P.ProjectID = EP.ProjectID
JOIN Employees E ON EP.EmployeeID = E.EmployeeID
WHERE P.EndDate IS NULL
ORDER BY E.EmployeeID

--08. Employee 24
SELECT E.EmployeeID,E.FirstName,
CASE
	WHEN YEAR(P.StartDate )>=2005 THEN NULL
	ELSE P.Name
END
FROM Employees E
JOIN EmployeesProjects EP ON EP.EmployeeID = E.EmployeeID
JOIN Projects P ON EP.ProjectID = P.ProjectID
WHERE E.EmployeeID = 24

--09. Employee Manager
SELECT E.EmployeeID,E.FirstName,E.ManagerID,M.FirstName 
FROM Employees E
JOIN Employees M ON E.ManagerID = M.EmployeeID
WHERE M.EmployeeID = 3 OR M.EmployeeID = 7
ORDER BY E.EmployeeID

--10. Employees Summary
SELECT TOP(50) 
E.EmployeeID,
E.FirstName + ' ' + E.LastName AS EmployeeName,
M.FirstName + ' ' + M.LastName AS ManagerName,
D.Name
FROM Employees E
JOIN Employees M ON E.ManagerID = M.EmployeeID
JOIN Departments D ON E.DepartmentID = D.DepartmentID
ORDER BY EmployeeID

--11. Min Average Salary
SELECT TOP(1)AVG(E.Salary) AVGSALARY
FROM Employees E
GROUP BY E.DepartmentID
ORDER BY AVGSALARY




