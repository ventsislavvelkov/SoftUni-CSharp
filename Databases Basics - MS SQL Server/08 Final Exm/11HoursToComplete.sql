  
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
BEGIN
	 DECLARE @totalHours INT;
	 
	 IF(@StartDate IS NULL)
	 BEGIN
	 	SET @totalHours = 0;
	 	RETURN @totalHours;
	 END;
	 
	 IF(@EndDate IS NULL)
	 BEGIN
	 	SET @totalHours = 0;
	 	RETURN @totalHours;
	 END;
	 
	 SET @totalHours = DATEDIFF(HOUR, @StartDate, @EndDate);
	 
	 RETURN @totalHours;
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
  FROM Reports