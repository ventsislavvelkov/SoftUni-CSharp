CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(MAX))
RETURNS @output TABLE(SumCash DECIMAL(15, 4))
AS
BEGIN
     INSERT INTO @output
          SELECT SUM([TempResult].Cash) AS [SumCash]
            FROM
                (
                    SELECT ug.Cash, 
                           ROW_NUMBER() OVER(PARTITION BY g.Id ORDER BY ug.Cash DESC) AS [RowRanking]
                    FROM Games AS g
                         JOIN UsersGames AS ug ON g.Id = ug.GameId
                    WHERE g.[Name] = @gameName
                    GROUP BY g.Id, 
                             ug.Cash
                )  AS [TempResult]
                WHERE [TempResult].[RowRanking] % 2 <> 0;
         RETURN;
END;

--Executing

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')