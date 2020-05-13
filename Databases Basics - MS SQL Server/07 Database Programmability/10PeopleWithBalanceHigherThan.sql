CREATE PROC usp_GetHoldersWithBalanceHigherThan(@number DECIMAL(15, 2))
AS
     SELECT ah.FirstName AS [First Name], 
            ah.LastName AS [Last Name]
     FROM Accounts AS a
          JOIN AccountHolders AS ah ON a.AccountHolderId = ah.Id
     GROUP BY ah.FirstName, 
              ah.LastName
     HAVING SUM(a.Balance) > @number
     ORDER BY ah.FirstName, 
              ah.LastName

--Executing 

EXEC dbo.usp_GetHoldersWithBalanceHigherThan 50000