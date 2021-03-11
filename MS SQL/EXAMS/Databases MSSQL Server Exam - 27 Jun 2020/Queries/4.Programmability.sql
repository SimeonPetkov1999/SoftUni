--12. Cost Of Order

CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(18,2)
AS
BEGIN
DECLARE @SUM DECIMAl(18,2)=(select SUM(p.Price)
						   from Parts p 
								join OrderParts op ON p.PartId = op.PartId
								JOIN Orders o ON op.OrderId = o.OrderId
								join jobs j ON o.JobId = j.JobId
						   where j.JobId = @JobId)
IF(@SUM IS NULL)
	RETURN 0

RETURN @SUM
END

SELECT dbo.udf_GetCost(3)
	