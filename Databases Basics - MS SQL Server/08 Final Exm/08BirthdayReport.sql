SELECT u.[Username], 
       c.[Name]
FROM Users AS u
     LEFT JOIN Reports AS r ON r.UserId = u.Id
     LEFT JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)
ORDER BY u.Username, 
         c.[Name]