--01. Records’ Count
SELECT COUNT(*)
FROM WizzardDeposits

--02. Longest Magic Wand
SELECT MAX(MagicWandSize)
FROM WizzardDeposits

--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize)
FROM WizzardDeposits
GROUP BY DepositGroup

--04. Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits WD
GROUP BY DepositGroup
ORDER BY AVG(WD.MagicWandSize)

--05. Deposits Sum
SELECT * FROM WizzardDeposits

SELECT WD.DepositGroup, SUM(WD.DepositAmount)
FROM WizzardDeposits WD
GROUP BY WD.DepositGroup

--06. Deposits Sum for Ollivander Family
SELECT WD.DepositGroup, SUM(WD.DepositAmount)
FROM WizzardDeposits WD
WHERE WD.MagicWandCreator = 'Ollivander family'
GROUP BY WD.DepositGroup

--07. Deposits Filter
SELECT WD.DepositGroup, SUM(WD.DepositAmount) AS [TotalSum]
FROM WizzardDeposits WD
WHERE WD.MagicWandCreator = 'Ollivander family'
GROUP BY WD.DepositGroup 
HAVING SUM(WD.DepositAmount)<150000
ORDER BY totalSum desc

--08. Deposit Charge
SELECT WD.DepositGroup,WD.MagicWandCreator,MIN(WD.DepositCharge)
FROM WizzardDeposits WD
GROUP BY WD.DepositGroup,WD.MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup

--09. Age Groups
SELECT A.AgeGroup, COUNT(A.AgeGroup) FROM(
SELECT 
CASE
	WHEN WD.Age >=0 AND WD.Age<=10 THEN '[0-10]'
	WHEN WD.Age >=11 AND WD.Age<=20 THEN '[11-20]'
	WHEN WD.Age >=21 AND WD.Age<=30 THEN '[21-30]'
	WHEN WD.Age >=31 AND WD.Age<=40 THEN '[31-40]'
	WHEN WD.Age >=41 AND WD.Age<=50 THEN '[41-50]'
	WHEN WD.Age >=51 AND WD.Age<=60 THEN '[51-60]'
	WHEN WD.Age >=61 THEN '[61+]'
END AS AgeGroup
FROM WizzardDeposits WD ) A
GROUP BY A.AgeGroup

--10. First Letter
SELECT DISTINCT LEFT(WD.FirstName,1)
FROM WizzardDeposits WD
WHERE WD.DepositGroup = 'Troll Chest'

--11. Average Interest
SELECT WD.DepositGroup,WD.IsDepositExpired,AVG(WD.DepositInterest)
FROM WizzardDeposits WD
WHERE WD.DepositStartDate > '01/01/1985'
GROUP BY WD.DepositGroup,WD.IsDepositExpired
ORDER BY WD.DepositGroup DESC,WD.IsDepositExpired

