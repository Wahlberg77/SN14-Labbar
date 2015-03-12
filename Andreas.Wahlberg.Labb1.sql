--Uppgift 1.1
SELECT ProductID,
		Name,
		Color,
		ListPrice
FROM Production.Product

--Uppgift 1.2
SELECT ProductID,
		Name,
		Color,
		ListPrice
FROM Production.Product
WHERE ListPrice > 0

--Uppgift 1.3
SELECT ProductID,
		Name,
		Color,
		ListPrice
FROM Production.Product
WHERE Color IS NULL

--Uppgift 1.4
SELECT ProductID,
		Name,
		Color,
		ListPrice
FROM Production.Product
WHERE Color IS NOT NULL

--Uppgift 1.5
SELECT ProductID,
		Name,
		Color,
		ListPrice
FROM Production.Product
WHERE Color IS NOT NULL AND ListPrice > 0

--Uppgift 1.6
SELECT Name + Color AS 'Name and Color'
FROM Production.Product
WHERE Color IS NOT NULL

--Uppgift 1.7
SELECT  'NAME: ' + Name + ' -- ' +  ' COLOR: ' + Color AS 'Name and Color'
FROM Production.Product as PP
WHERE Color IS NOT NULL 
		AND Name = 'LL Crankarm'
		AND COLOR = 'Black'

--Uppgift 1.8
SELECT ProductID, 
		Name
FROM Production.Product AS PP
WHERE ProductID BETWEEN 400 AND 500

--Uppgift 1.9
SELECT ProductID, 
		Name,
		Color
FROM Production.Product AS PP
WHERE PP.Color = 'Black' OR PP.Color = 'Blue'

--Uppgift 1.10
SELECT Name,
		ListPrice
FROM Production.Product AS PP
WHERE PP.NAME LIKE 'S%'

--Uppgift 1.11
SELECT Name,
		ListPrice
FROM Production.Product AS PP
WHERE PP.Name LIKE 'S%' OR PP.Name LIKE 'A%';

--Uppgift 1.12
SELECT Name,
		ListPrice
FROM Production.Product AS PP
WHERE PP.Name LIKE 'SPO[K]%'; -- Finns inga som har K i sig under Name?

--Uppgift 1.13
 SELECT DISTINCT Color
 FROM Production.Product AS PP
 WHERE Color IS NOT NULL

 --Uppgift 1.14
SELECT ProductSubcategoryID, 
		Color
FROM Production.Product AS PP
WHERE Color IS NOT NULL 
		AND ProductSubcategoryID IS NOT NULL
ORDER BY ProductSubcategoryID ASC, 
		Color DESC

--Uppgift 1.15
SELECT ProductSubCategoryID 
 , LEFT([Name],35) AS [Name]
 , Color, ListPrice
FROM Production.Product
WHERE Color IN ('Red','Black')
 AND ProductSubCategoryID = 1
 AND ListPrice BETWEEN 1000 AND 2000
ORDER BY ProductSubcategoryID--Uppgift 1.16SELECT Name, ISNULL(Color , 'Unknown') AS 'Color', ListPriceFROM Production.Product AS PP

--Uppgift 2.1
SELECT COUNT (ProductID)
FROM Production.Product AS PP

--Uppgift 2.2
SELECT COUNT (ProductSubcategoryID) AS 'NumberOfArticleInSubcategorys'
FROM Production.Product AS PP

--Uppgift 2.3
SELECT COUNT(PP.ProductSubcategoryID) AS 'NumbersOfArticle'
FROM Production.Product AS PP
GROUP BY PP.ProductSubcategoryID

--Uppgift 2.4 A
SELECT COUNT(*) - COUNT(ProductSubcategoryID) 
FROM Production.Product

--Uppgift 2.4 B
SELECT COUNT(*) AS NoSub FROM Production.Product
WHERE ProductSubcategoryID IS NULL

--Uppgift 2.5
SELECT ProductID, SUM(quantity) AS Summan
FROM Production.ProductInventory
GROUP BY ProductID

--Uppgift 2.6
SELECT ProductID, SUM(quantity) AS Summan
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(quantity) < 100

--Uppgift 2.7
SELECT Shelf AS Hyllplats,
		ProductID, 
		SUM(quantity) AS Summan
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID, Shelf
HAVING SUM(quantity) < 100

--Uppgift 2.8
SELECT AVG(Quantity) AS MedelAntal
FROM Production.ProductInventory
Where LocationID = 10

--Uppgift 2.9
SELECT ROW_NUMBER() 
		OVER (ORDER BY Name) AS Produktnamn
		,Name 
FROM Production.ProductCategory
ORDER BY Produktnamn

--Uppgift 3.1
SELECT PCR.[Name] AS Land,
		PSP.[Name] AS Provinser
FROM Person.CountryRegion AS PCR
		JOIN Person.StateProvince AS PSP
		ON PCR.CountryRegionCode = PSP.CountryRegionCode

--Uppgift 3.2
SELECT PCR.[Name] AS Country,
		PSP.[Name] AS Province
FROM Person.CountryRegion AS PCR
		JOIN Person.StateProvince AS PSP
		ON PCR.CountryRegionCode = PSP.CountryRegionCode
WHERE PCR.[Name] IN ('Germany' , 'Canada')
ORDER BY Country ASC, Province ASC

--Uppgift 3.3
SELECT SOH.SalesOrderID, -- Går det inte att slå ihop dessa på samma rad? Inom samma [ ]?
		SOH.OrderDate,
		SOH.SalesPersonID,
		SSP.BusinessEntityID,
		SSP.Bonus,
		SSP.SalesYTD
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Sales.SalesPerson AS SSP
		ON SOH.SalesPersonID = SSP.BusinessEntityID

--Uppgift 3.4
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		HRE.JobTitle,
		SSP.Bonus,
		SSP.SalesYTD
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Sales.SalesPerson AS SSP 
		ON SOH.SalesPersonID = SSP.BusinessEntityID
		INNER JOIN HumanResources.Employee AS HRE
		ON SSP.BusinessEntityID = SSP.BusinessEntityID

--Uppgift 3.5
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		SSP.Bonus,
		SSP.SalesYTD,
		PP.FirstName,
		PP.LastName
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Sales.SalesPerson AS SSP 
		ON SOH.SalesPersonID = SSP.BusinessEntityID
		INNER JOIN HumanResources.Employee AS HRE
		ON SSP.BusinessEntityID = SSP.BusinessEntityID
		INNER JOIN Person.Person AS PP
		ON HRE.BusinessEntityID = PP.BusinessEntityID

--Uppgift 3.6
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		SSP.Bonus,
		PP.FirstName,
		PP.LastName
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Sales.SalesPerson AS SSP 
		ON SOH.SalesPersonID = SSP.BusinessEntityID
		INNER JOIN Person.Person AS PP
		ON SSP.BusinessEntityID = PP.BusinessEntityID;

--Uppgift 3.7
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		PP.FirstName,
		PP.LastName
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Person.Person AS PP
		ON SOH.SalesPersonID = PP.BusinessEntityID;

--Uppgift 3.8
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		PP.FirstName + ' ' + PP.LastName AS SalesPerson
FROM Sales.SalesOrderHeader AS SOH
		INNER JOIN Person.Person AS PP
		ON SOH.SalesPersonID = PP.BusinessEntityID
		INNER JOIN Sales.SalesOrderDetail AS SOD
		ON SOH.SalesOrderID = SOD.SalesOrderID
		ORDER BY OrderDate, SalesOrderID
		
--Uppgift 3.9
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		PP.FirstName + ' ' + PP.LastName AS SalesPerson,
		P.Name AS ProductName,
		SOD.OrderQty
FROM Sales.SalesOrderHeader AS SOH
 INNER JOIN Person.Person AS PP
    ON SOH.SalesPersonID = PP.BusinessEntityID
 INNER JOIN Sales.SalesOrderDetail AS SOD
    ON SOH.SalesOrderID = SOD.SalesOrderID
 INNER JOIN Production.Product AS P 
    ON P.ProductID = SOD.ProductID
ORDER BY OrderDate, SalesOrderID

--Uppgift 3.10 LYCKAS INTE FÅ DENNA ATT SKRIVA UT NÅGOT RESULTAT???
SELECT SOH.SalesOrderID,
		SOH.OrderDate,
		PP.FirstName + ' ' + PP.LastName AS SalesPerson,
		P.Name AS ProductName,
		SOD.OrderQty
FROM Sales.SalesOrderHeader AS SOH
 INNER JOIN Person.Person AS PP
    ON SOH.SalesPersonID = PP.BusinessEntityID
 INNER JOIN Sales.SalesOrderDetail AS SOD
    ON SOH.SalesOrderID = SOD.SalesOrderID
 INNER JOIN Production.Product AS P 
    ON P.ProductID = SOD.ProductID
WHERE SOH.SubTotal > 100000
		--AND SOH.OrderDate BETWEEN '20040401' AND '20041231'
		AND YEAR(SOH.OrderDate) = 2014
ORDER BY OrderDate, SalesOrderID

--Uppgift 3.11
SELECT CR.Name AS CountryName,
		PS.Name AS ProvinceName
FROM Person.CountryRegion AS CR
  LEFT OUTER JOIN Person.StateProvince AS PS
    ON CR.CountryRegionCode = PS.CountryRegionCode
ORDER BY CountryName, ProvinceName

--Uppgift 3.12
SELECT SC.CustomerID, 
		SOH.SalesOrderID 
FROM Sales.Customer AS SC
LEFT OUTER JOIN Sales.SalesOrderHeader AS SOH 
        ON SC.CustomerID = SOH.CustomerID
WHERE SOH.SalesOrderID IS NULL
ORDER BY CustomerID

--Uppgift 3.13
SELECT PP.[Name] AS ProductName,
		PPM.[Name] AS ProductModelName
FROM Production.Product AS PP
     FULL OUTER JOIN Production.ProductModel AS PPM 
        ON PP.ProductModelID = PPM.ProductModelID
WHERE PP.[Name] IS NULL OR PPM.[Name] IS NULL

--Uppgift 3.14 Del 1
SELECT SP.BusinessEntityID, 
		LEFT(PP.firstname + ' ' + PP.LastName, 30) AS FullName 
FROM Sales.SalesPerson AS SP
     INNER JOIN HumanResources.Employee AS HRE
        ON HRE.BusinessEntityID  = SP.BusinessEntityID
     INNER JOIN Person.Person AS PP
        ON PP.BusinessEntityID  = HRE.BusinessEntityID

--Uppgift 3.14 Del 2
SELECT SP.BusinessEntityID, 
		LEFT(PP.firstname + ' ' + PP.lastname,30) AS FullName,
		SUM(SOH.SubTotal) AS [TotalSum],
		COUNT(SOH.SalesPersonID) AS [NoOfOrders] 
FROM Sales.SalesPerson AS SP
     INNER JOIN HumanResources.Employee AS HRE
        ON HRE.BusinessEntityID  = SP.BusinessEntityID 
     INNER JOIN Person.Person AS PP
        ON PP.BusinessEntityID  = HRE.BusinessEntityID
	INNER JOIN Sales.SalesOrderHeader AS SOH
       ON SP.BusinessEntityID = SOH.SalesPersonID
GROUP BY SP.BusinessEntityID,
		LEFT(PP.FirstName + ' ' + PP.LastName, 30)

--Uppgift 3.15
SELECT DATEPART(YEAR,OrderDate) AS [Year],
		LEFT([Name], 25) AS Region,
		SUM(SubTotal) AS SumTotal 
FROM Sales.SalesOrderHeader AS SOH
      JOIN Sales.SalesTerritory AS ST 
         ON  SOH.TerritoryID = ST.TerritoryID
GROUP BY DATEPART(year, SOH.OrderDate), [Name] 
ORDER BY [Name] DESC,
		DATEPART(year,OrderDate) ASC

--Uppgift 3.16
SELECT HRE.BusinessEntityID,
      LEFT(PP.Lastname,10) AS LastName,
      COUNT(EDH.DepartmentID) AS [DepartmentCount]
FROM HumanResources.EmployeeDepartmentHistory AS EDH
      JOIN HumanResources.Employee AS HRE 
         ON EDH.BusinessEntityID = HRE.BusinessEntityID
      JOIN Person.Person AS PP 
         ON HRE.BusinessEntityID = PP.BusinessEntityID
GROUP BY HRE.BusinessEntityID, PP.Lastname
HAVING COUNT(EDH.DepartmentID) > 1

--Uppgift 3.17
SELECT 'Lägsta Ordervärde: ' + CAST(MIN(SubTotal) 
      AS VARCHAR(20)) AS [Liten säljrapport] 
FROM  Sales.SalesOrderHeader
	UNION
SELECT 'Högsta Ordervärde: ' + CAST(MAX(SubTotal) 
      AS VARCHAR(20)) 
FROM  Sales.SalesOrderHeader
	UNION
SELECT 'Medelvärde per Order: ' + CAST(AVG(SubTotal) 
      AS VARCHAR(20)) 
FROM  Sales.SalesOrderHeader

--Uppgift 3.18
SELECT TOP(10) ListPrice, Name 
FROM Production.Product
ORDER BY ListPrice DESC

--Uppgift 3.19
SELECT TOP(1) PERCENT 
		DaysToManufacture, 
		Name
FROM Production.Product
ORDER BY DaysToManufacture DESC


	 













