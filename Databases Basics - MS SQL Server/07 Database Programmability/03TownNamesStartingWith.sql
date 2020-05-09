CREATE PROC usp_GetTownsStartingWith(@startingString NVARCHAR(MAX))
AS
	SELECT t.[Name] AS [Town]
	  FROM Towns AS t
	 WHERE t.[Name] LIKE @startingString + '%'

-- Executing
GO
EXEC dbo.usp_GetTownsStartingWith 'Bell'