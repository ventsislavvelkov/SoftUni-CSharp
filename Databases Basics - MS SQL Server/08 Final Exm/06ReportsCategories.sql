SELECT [Description], 
       c.[Name] AS [CategoryName]
FROM Reports AS r
     JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY [Description], 
         c.[Name]