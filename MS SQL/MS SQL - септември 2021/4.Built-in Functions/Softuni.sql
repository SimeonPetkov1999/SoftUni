--01. Find Names of All Employees by First Name
SELECT e.FirstName,e.LastName
FROM Employees e
WHERE e.FirstName Like 'Sa%'

--02. Find Names of All Employees by Last Name
SELECT e.FirstName,e.LastName
FROM Employees e
WHERE e.LastName Like '%ei%'

--03. Find First Names of All Employess
SELECT e.FirstName
FROM Employees e
WHERE e.DepartmentID IN(3,10) AND (Year(e.HireDate) >=1995 AND Year(e.HireDate)<=2005) 

--4. Find All Employees Except Engineers
SELECT e.FirstName,e.LastName
FROM Employees e
WHERE E.JobTitle NOT LIKE '%ENGINEER%'

--05. Find Towns with Name Length
SELECT T.Name
FROM Towns T
WHERE LEN(T.Name) = 5 OR LEN(T.Name) = 6 
ORDER BY T.Name

--06. Find Towns Starting With
SELECT *
FROM Towns T
WHERE T.Name LIKE 'M%' OR T.Name LIKE 'K%' OR T.Name LIKE 'B%' OR T.Name LIKE 'E%'
ORDER BY T.Name

--07. Find Towns Not Starting With
SELECT *
FROM Towns T
WHERE T.Name NOT LIKE 'R%' AND T.Name NOT LIKE 'B%' AND T.Name NOT LIKE 'D%'
ORDER BY T.Name

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT E.FirstName,E.LastName 
FROM Employees E
WHERE YEAR(E.HireDate) > 2000

--09. Length of Last Name
SELECT E.FirstName, E.LastName 
FROM Employees E
WHERE LEN(E.LastName) = 5
 
--10. Rank Employees by Salary
SELECT E.EmployeeID,E.FirstName,E.LastName,E.Salary,
DENSE_RANK() OVER(PARTITION BY E.Salary ORDER BY E.EmployeeID)
FROM Employees E
WHERE e.Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC


--11. Find All Employees with Rank 2
SELECT * FROM(
SELECT E.EmployeeID,E.FirstName,E.LastName,E.Salary,
DENSE_RANK() OVER(PARTITION BY E.Salary ORDER BY E.EmployeeID) AS [Rank]
FROM Employees E
WHERE Salary BETWEEN 10000 AND 50000) A
WHERE a.[Rank] = 2 
ORDER BY A.Salary DESC