   SELECT TownId,
          [Name]
     FROM Towns
    WHERE [Name] LIKE '^[RBD]%'
 ORDER BY [Name]

 SELECT TownId,
          [Name]
     FROM Towns
    WHERE [Name] NOT LIKE '[RBD]%'
 ORDER BY [Name]