SELECT OrderID, ShippedDate, ShipVia FROM Orders
WHERE ShippedDate >= CONVERT(DATETIME,'19980506',102) AND ShipVia >= 2;
/*Сравнение NULL объекта с текущим нашим условием вернет UNKNOWN и оно не будет 
входит в наш SELECT. И следовательно мы не видем колонок с NULL объектом.*/

SELECT OrderID,/*Так как на колонку даты не можем написать строку, я его слегка заменил.*/
CASE
	WHEN ShippedDate IS NULL THEN 'Not shipped'
END AS 'ShippedDate'
FROM Orders
WHERE ShippedDate IS NULL;

SELECT ContactName, Country From Customers
WHERE Country IN ('USA', 'Canada')
ORDER BY ContactName,Country;

SELECT ContactName, Country From Customers
WHERE Country NOT IN ('USA', 'Canada')
ORDER BY ContactName;

SELECT DISTINCT Country FROM Customers
WHERE Country IS NOT NULL
ORDER BY Country DESC;

(7) SELECT DISTINCT OrderID FROM [Order Details]
WHERE Quantity BETWEEN 3 AND 10;

SELECT CustomerID, Country FROM Customers
WHERE Country BETWEEN 'b' AND 'h'
ORDER BY Country;

SELECT ProductName FROM Products
WHERE ProductName LIKE '%cho_olade%';

SELECT YEAR(ShippedDate) AS 'Year',COUNT(YEAR(ShippedDate)) AS 'Total' FROM Orders
WHERE YEAR(ShippedDate) IS NOT NULL
GROUP BY YEAR(ShippedDate)
ORDER BY YEAR(ShippedDate);


SELECT ContactName FROM Customers
WHERE EXISTS(SELECT  OrderDate FROM Orders
WHERE Customers.CustomerID = Orders.CustomerID AND ShippedDate IS NULL);
