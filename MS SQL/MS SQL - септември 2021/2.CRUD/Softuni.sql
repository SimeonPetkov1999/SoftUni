--02. Find All Information About Departments
select * from Departments

--03. Find all Department Names
select d.Name from Departments d

--04. Find Salary of Each Employee
select e.FirstName, e.LastName, e.Salary from Employees e 

--05. Find Full Name of Each Employee
select e.FirstName, e.MiddleName, e.LastName from Employees e

--06. Find Email Address of Each Employee
select e.FirstName+'.'+e.LastName+'@softuni.bg' as [Full Email Address] from Employees e

--07. Find All Different Employee’s Salaries
select distinct e.Salary as Salary from Employees e

--08. Find all Information About Employees
select * from Employees
where JobTitle = 'Sales Representative'

--09. Find Names of All Employees by Salary in Range
select e.FirstName, e.LastName, e.JobTitle from Employees e
where Salary Between 20000 and 30000

--10. Find Names of All Employees
select Concat(e.FirstName,' ',e.MiddleName,' ',e.LastName)  from Employees e
where e.Salary IN(25000,14000,12500,23600)

--11. Find All Employees Without Manager
Select e.FirstName, e.LastName from Employees e
where e.ManagerID is null

--12. Find All Employees with Salary More Than
select e.FirstName, e.LastName,e.Salary from Employees e
where e.Salary>50000
order by e.Salary desc

--13. Find 5 Best Paid Employees
select top(5) e.FirstName, e.LastName from Employees e
order by e.Salary desc

--14. Find All Employees Except Marketing
select e.FirstName,e.LastName from Employees e
where e.DepartmentID != 4

--15. Sort Employees Table
select * from Employees e
order by e.Salary desc, e.FirstName asc, e.LastName desc, e.MiddleName asc

--16. Create View Employees with Salaries
create view V_EmployeesSalaries as
select e.FirstName, e.LastName, e.Salary from Employees e 

--17. Create View Employees with Job Titles
create view V_EmployeeNameJobTitle as
select e.FirstName + ' '+
case  
when e.MiddleName is null then ''
else e.MiddleName
end +' ' +
e.LastName as [Full Name],
e.JobTitle
from Employees e

CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName +' '+ ISNULL(MiddleName,'') +' '+LastName AS [Full Name],JobTitle AS [Job Tittle] 
FROM Employees

--18. Distinct Job Titles
select distinct e.JobTitle from Employees e

--19. Find First 10 Started Projects
select top(10) * from Projects p
order by p.StartDate,p.Name

--20. Last 7 Hired Employees
select top(7) e.FirstName,e.LastName,e.HireDate from Employees e
order by e.HireDate desc

--21. Increase Salaries 1,2,4,11
update Employees 
set Salary*=1.12
where DepartmentID IN(1,2,4,11)

select Salary from Employees e