--13. Departments Total Salaries
SELECT E.DepartmentID, SUM(E.Salary)
FROM Employees E
GROUP BY E.DepartmentID

--14. Employees Minimum Salaries
SELECT E.DepartmentID, MIN(E.Salary)
FROM Employees E
WHERE E.DepartmentID IN(2,5,7) AND E.HireDate>'01/01/2000'
GROUP BY E.DepartmentID

--15. Employees Average Salaries
SELECT DepartmentID,EmployeeID,ManagerID,Salary
INTO EmployeeWithSalaryOver30000
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeeWithSalaryOver30000
WHERE ManagerID = 42

UPDATE EmployeeWithSalaryOver30000
SET Salary+= 5000
WHERE DepartmentID =1

SELECT DepartmentID, AVG(Salary)
FROM EmployeeWithSalaryOver30000
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT E.DepartmentID, MAX(E.Salary)
FROM Employees E
GROUP BY E.DepartmentID
HAVING MAX(E.Salary) <30000 OR  MAX(E.Salary) >70000

--17. Employees Count Salaries
SELECT COUNT(*)
FROM Employees E
WHERE E.ManagerID IS NULL

--18. 3rd Highest Salary
SELECT a.DepartmentID, a.Salary AS ThirdHighestSalary
FROM(SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID  ORDER BY Salary DESC) AS Ranked
FROM Employees
GROUP BY DepartmentID,Salary) as a
WHERE a.Ranked=3


