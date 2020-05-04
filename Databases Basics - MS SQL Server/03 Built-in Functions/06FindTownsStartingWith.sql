 SELECT TownId,
          [Name]
     FROM Towns
    WHERE [Name] LIKE '[MKBE]%'
 ORDER BY [Name]

  SELECT TownId,
         [Name]
    FROM Towns
   WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]