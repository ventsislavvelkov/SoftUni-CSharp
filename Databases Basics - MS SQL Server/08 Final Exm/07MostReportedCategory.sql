SELECT TOP (5) c.[Name] AS [CategoryName], 
               COUNT(r.Id) AS [ReportsNumber]
FROM Categories AS c
     JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY COUNT(r.Id) DESC, 
         c.[Name]