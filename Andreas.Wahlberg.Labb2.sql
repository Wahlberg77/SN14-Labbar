-- Uppgift 4.0
BACKUP DATABASE AdventureWorks2014
TO DISK = 'C:\MyBackups\AW_BU.bak';

-- Uppgift 4.1
SELECT LastName 
FROM Person.Person

BEGIN TRANSACTION 
UPDATE Person.Person
SET LastName = 'Hult';
ROLLBACK TRANSACTION

SELECT @@TRANCOUNT AS ActiveTransactions

--Uppgift 4.2
CREATE TABLE [dbo].[TempCustomers]
(
[ContactID] [int] NULL,
[FirstName] [nvarchar](50) NULL,
[LastName] [nvarchar](50) NULL,
[City] [nvarchar](30) NULL,
[StateProvince] [nvarchar](50) NULL
)
GO

INSERT INTO dbo.TempCustomers -- Utan kolumnlistan, funkar ej. 
VALUES (1, 'Kalen', 'Delaney'),
		(2, 'Herman', 'Karlsson', 'Vislanda', 'Kronoberg');

INSERT INTO dbo.TempCustomers (ContactID, FirstName, LastName, City) -- med kolumnlistan. Funkar fint serru. 
VALUES (3, 'Tora', 'Eriksson', 'Guldsmedshyttan'),
		(4, 'Charlie', 'Carpenter', 'Tappström');

SELECT ContactID, 
		FirstName, 
		LastName, 
		City,
		StateProvince
FROM dbo.TempCustomers

--Uppgift 4.3
INSERT INTO Production.Product (Name, ProductNumber, SafetyStockLevel, ReorderPoint, StandardCost, ListPrice
								, DaysToManufacture, SellStartDate)
VALUES ('Racing Gizmo', 251, 1, 3, 2595, 2695, 20, GETDATE());

--Uppgift 4.4
INSERT INTO DBO.TempCustomers
		(ContactID, FirstName, LastName, City, StateProvince)

SELECT P.BusinessEntityID, P.FirstName, P.LastName, PA.City, SP.Name

FROM Person.Person AS P
	JOIN Person.BusinessEntity AS BE
ON P.BusinessEntityID=BE.BusinessEntityID
	JOIN Person.BusinessEntityAddress AS BEA
ON BE.BusinessEntityID = BEA.BusinessEntityID
	JOIN Person.Address PA
ON BEA.AddressID=PA.AddressID
	JOIN Person.StateProvince AS SP
ON PA.StateProvinceID = SP.StateProvinceID

--Uppgift 4.5
-- Töm tabellen
-- och töm buffer och cache
TRUNCATE TABLE dbo.TempCustomers
GO
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE
GO
-- Lägg till data och mät tiden
DECLARE @Start DATETIME2, @Stop DATETIME2
SELECT @Start = SYSDATETIME()

INSERT INTO dbo.TempCustomers (ContactID, FirstName, LastName)
SELECT BusinessEntityID, FirstName, LastName
FROM Person.Person

SELECT @Stop = SYSDATETIME()
SELECT DATEDIFF(ms, @Start, @Stop) as MilliSeconds

--Första frågan - tom cold cache = 96ms fick inget fel om att det saknades kolumner i Insert?
--Andra frågan - fylld varm cache = ca 70ms.
--Tredje frågan - tom cold cache = 210ms
--Fjärde frågan - fylld varm cache = ca 180ms

CREATE UNIQUE CLUSTERED INDEX [Unique_Clustered]
ON [dbo].[TempCustomers]
( [ContactID] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_FName]
ON [dbo].[TempCustomers]
( [FirstName] ASC )
GO
CREATE NONCLUSTERED INDEX [NonClustered_LName]
ON [dbo].[TempCustomers]
( [LastName] ASC )
GO
--Uppgift 4.6
SELECT BusinessEntityID, PersonType, FirstName, LastName, Title,EmailPromotion
INTO #TempTab
FROM PERSON.Person
WHERE LastName IN ('Achong', 'Acevedo') 

SELECT * FROM #TempTab--Del 2
UPDATE dbo.#TempTab
SET BusinessEntityID = 
	(
		SELECT MAX(P.BusinessEntityID) + 1
		FROM Person.Person AS P
	)
INSERT INTO Person.Person 
			(BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion)
SELECT BusinessEntityID, PersonType, FirstName, LastName, Title, EmailPromotion
FROM #TempTab

INSERT INTO Person.BusinessEntity
VALUES (DEFAULT, DEFAULT)

DROP TABLE #TempTab;

SELECT P.FirstName, P.BusinessEntityID, ModifiedDate -- Nya raderna finns med i Person.Person
FROM Person.Person AS P
WHERE ModifiedDate > '2015-03-10'

--Uppgift 4.7
UPDATE Person.Person
SET FirstName = 'Gurra', LastName = 'Tjong'
WHERE BusinessEntityID IN 
	(
		SELECT BusinessEntityID
		FROM Person.Person 
		WHERE LastName IN ('Achong', 'Acevedo')
	)
--Uppgift 4.8
SELECT PP.Name, PP.ListPrice * 1.1 AS 'ListPrice 10%'
FROM Production.Product AS PP
INNER JOIN Production.ProductSubcategory as PPS
		ON PPS.ProductSubcategoryID = PP.ProductSubcategoryID
WHERE PPS.Name = 'Gloves'

--Uppgift 4.9
DELETE FROM dbo.TempCustomers
WHERE LastName = 'Smith'

-- Alla Smith är borta, men inte Smith-Bates. 
SELECT LastName
FROM dbo.TempCustomers 
WHERE LastName LIKE 'SM%'

