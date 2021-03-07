--1. Create Table Logs
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
	OldSum MONEY,
	NewSum MONEY
)

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId,OldSum,NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	JOIN deleted AS d ON i.Id = d.Id
	WHERE i.Balance != d.Balance
GO

--2. Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT FOREIGN KEY REFERENCES Accounts(Id),
	[Subject] NVARCHAR(MAX),
	Body NVARCHAR(MAX)
)

CREATE OR ALTER TRIGGER tr_logTableEmails 
ON Logs FOR INSERT
AS
	DECLARE @Recipient INT = (SELECT AccountID FROM inserted)
	DECLARE @Subject NVARCHAR(MAX) = (SELECT 'Balance change for account: ' + CAST(AccountID as nvarchar)  FROM inserted)
	DECLARE @Body NVARCHAR(MAX) = (SELECT 'On ' + CAST(GETDATE() as nvarchar)  + ' your balance was changed from ' + CAST(OldSum as nvarchar)  + ' to ' + CAST(NewSum as nvarchar)  FROM inserted)
	INSERT INTO NotificationEmails(Recipient,Subject,Body)
	VALUES (@Recipient,@Subject,@Body)
GO

--3. Deposit Money
CREATE PROCEDURE usp_DepositMoney (@AccountId INT , @MoneyAmount DECIMAL(10,4))
AS 
BEGIN TRANSACTION 
	IF(@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Money must be a positive number!!!',1
	END	
UPDATE Accounts 
 SET Balance += @MoneyAmount
 WHERE Id = @AccountId
COMMIT

EXEC usp_DepositMoney @AccountID = 1,@MoneyAmount = 100000

--4. Withdraw Money
CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT , @MoneyAmount DECIMAL(10,4))
AS
BEGIN TRANSACTION
	IF(@MoneyAmount < 0)
	BEGIN
		ROLLBACK;
		THROW 50001, 'Money must be a positive number!!!',1
	END	
UPDATE Accounts 
 SET Balance -= @MoneyAmount
 WHERE Id = @AccountId
COMMIT

EXEC usp_WithdrawMoney @AccountID = 1,@MoneyAmount = 10