--13. Departments Total Salaries
SELECT DepartmentID,SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

--14. Employees Minimum Salaries
SELECT DepartmentID,MIN(Salary) AS MinimumSalary
FROM Employees e
WHERE e.DepartmentID IN (2,5,7) AND e.HireDate>'2000-01-01'
GROUP BY DepartmentID
ORDER BY DepartmentID

--15. Employees Average Salaries
SELECT DepartmentID,EmployeeID,ManagerID,Salary
INTO EmployeeWithSalaryOver30000
FROM Employees
WHERE Salary > 30000

UPDATE EmployeeWithSalaryOver30000
SET Salary +=5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeeWithSalaryOver30000
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID,MAX(Salary) AS MaxSalary
FROM Employees e
GROUP BY DepartmentID
HAVING MAX(Salary) <30000 OR MAX(Salary)>70000

--17. Employees Count Salaries
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--18. *3rd Highest Salary
SELECT a.DepartmentID, a.Salary AS ThirdHighestSalary
FROM(SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID  ORDER BY Salary DESC) AS Ranked
FROM Employees
GROUP BY DepartmentID,Salary) as a
WHERE a.Ranked=3

