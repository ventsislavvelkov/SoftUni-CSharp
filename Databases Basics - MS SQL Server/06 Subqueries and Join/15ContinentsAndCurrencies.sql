SELECT [TempResult].ContinentCode, 
       [TempResult].CurrencyCode, 
       [TempResult].[CurrencyUsage]
FROM
   (
    SELECT c.ContinentCode, 
           c.CurrencyCode, 
           COUNT(c.CurrencyCode) AS [CurrencyUsage], 
           DENSE_RANK() OVER(PARTITION BY c.ContinentCode
           ORDER BY COUNT(c.CurrencyCode) DESC) AS [CurrencyRank]
    FROM Countries AS c
    GROUP BY c.ContinentCode, 
             c.CurrencyCode
    HAVING COUNT(c.CurrencyCode) > 1
   ) AS [TempResult]
WHERE [CurrencyRank] = 1
ORDER BY [TempResult].ContinentCode