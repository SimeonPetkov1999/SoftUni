--Section 1. DDL (30 pts)
CREATE DATABASE CigarShop
USE CigarShop

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	Length INT CHECK([Length] >= 10 AND Length<=25) NOT NULL,
	RingRange DECIMAL(18,2) CHECK(RingRange >= 1.5 AND RingRange<=7.5) NOT NULL,
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription NVARCHAR(MAX),
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT FOREIGN KEY REFERENCES Brands(Id) NOT NULL,
	TastId INT FOREIGN KEY REFERENCES Tastes(Id) NOT NULL,
	SizeId INT FOREIGN KEY REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(18,4) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
	CigarId INT FOREIGN KEY REFERENCES Cigars(Id) NOT NULL,
	PRIMARY KEY(ClientId,CigarId)
)

--Section 2. DML (10 pts)
INSERT INTO Cigars(CigarName,BrandId,TastId,SizeID,PriceForSingleCigar,ImageURL)
VALUES
('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town,Country,Streat,ZIP)
VALUES
('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
('Athens','Greece','4342 McDonald Avenue','10435'),
('Zagreb','Croatia','4333 Lauren Drive','10000')

UPDATE Cigars 
SET PriceForSingleCigar*=1.20
FROM Cigars C
JOIN Tastes T ON C.TastId = T.Id
WHERE T.TasteType = 'Spicy'

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

SELECT C.CigarName,C.PriceForSingleCigar
FROM Cigars C
JOIN Tastes T ON C.TastId = T.Id
WHERE T.TasteType = 'Spicy'

DELETE Clients
FROM Clients C
INNER JOIN Addresses A ON  C.AddressId = A.Id
WHERE Country LIKE 'C%'

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--Section 3. Querying (40 pts)
SELECT C.CigarName,C.PriceForSingleCigar,C.ImageURL 
FROM Cigars C
ORDER BY C.PriceForSingleCigar ASC,C.CigarName DESC

SELECT C.Id,C.CigarName,C.PriceForSingleCigar,T.TasteType,T.TasteStrength 
FROM Cigars C
JOIN Tastes T ON C.TastId = T.Id
WHERE T.TasteType = 'Earthy' OR T.TasteType = 'Woody'
ORDER BY C.PriceForSingleCigar DESC


SELECT C.Id,C.FirstName + ' ' + C.LastName AS ClientName,C.Email 
FROM Clients C
LEFT JOIN ClientsCigars CC ON C.Id = CC.ClientId 
WHERE CC.ClientId IS NULL
ORDER BY ClientName 

SELECT TOP(5) C.CigarName,C.PriceForSingleCigar,C.ImageURL
FROM Cigars C
JOIN Sizes S ON C.SizeID = S.Id
WHERE (S.Length>=12 AND C.CigarName LIKE '%ci%') OR (C.PriceForSingleCigar>50 AND S.RingRange >2.55)
ORDER BY C.CigarName ASC,C.PriceForSingleCigar DESC

SELECT TOP (5) [CigarName], [PriceForSingleCigar], [ImageURL]
FROM [Cigars] c
LEFT JOIN [Sizes] s ON c.[SizeId] = s.[Id]
WHERE [Length] >=12 AND ([CigarName] LIKE '%ci%' OR [PriceForSingleCigar] > 50)AND [RingRange] > 2.55
ORDER BY [CigarName], [PriceForSingleCigar] DESC

SELECT C.FirstName + ' ' + C.LastName AS FullName,
A.Country,
A.ZIP,
CONCAT('$', MAX(cg.PriceForSingleCigar)) AS CigarPrice
FROM Clients AS C
JOIN Addresses A ON C.AddressId = A.Id
JOIN ClientsCigars CC ON C.Id  = CC.ClientId
JOIN Cigars CG ON CC.CigarId = CG.Id
WHERE A.ZIP NOT LIKE '%[^0-9]%'
GROUP BY C.FirstName, C.LastName, A.Country, A.ZIP
ORDER BY FullName 

SELECT C.LastName, AVG(S.[Length]) CigarLength,
CEILING(AVG(S.RingRange)) CigarRingRange
FROM Clients C
JOIN ClientsCigars CC ON C.Id = CC.ClientId
JOIN Cigars CG ON CC.CigarId = CG.Id
JOIN Sizes S ON CG.SizeId = S.Id
GROUP BY C.LastName
ORDER BY CigarLength DESC

--Section 4. Programmability (20 pts)
CREATE FUNCTION udf_ClientWithCigars(@INPUT NVARCHAR(MAX))
RETURNS INT
AS
BEGIN	
	DECLARE @NumOfCigars INT = (SELECT COUNT(*)
					FROM Clients AS C
					JOIN ClientsCigars CC ON C.Id = CC.ClientId
					JOIN Cigars AS CG ON CC.CigarId = CG.Id
					WHERE c.FirstName = @INPUT);
	RETURN @NumOfCigars			   		 	  	  
END

SELECT dbo.udf_ClientWithCigars('Betty') 

CREATE PROCEDURE usp_SearchByTaste(@TASTE NVARCHAR(20))
AS
	SELECT C.CigarName,
			CONCAT('$',C.PriceForSingleCigar) Price,
			T.TasteType,
			B.BrandName,
			CONCAT(S.Length, ' cm') CigarLength,
			CONCAT(S.RingRange, ' cm') CigarRingRange
	FROM Tastes T
	JOIN Cigars C ON T.Id = C.TastId
	JOIN Sizes S ON C.SizeId = S.Id
	JOIN Brands B ON C.BrandId = B.Id
	WHERE T.TasteType = @TASTE
	ORDER BY CigarLength, CigarRingRange DESC
GO