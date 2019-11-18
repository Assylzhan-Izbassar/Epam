CREATE PROCEDURE ShippedOrdersDiff( @r int)
AS 
BEGIN
SELECT OrderId, OrderDate, ShippedDate, DATEDIFF(DD,ShippedDate,OrderDate) 
AS 'ShippedDeley', @r AS 'SpecifiedDelay' FROM Orders
WHERE DATEDIFF(DD, ShippedDate,OrderDate) > @r OR ShippedDate IS NULL;
END 
GO