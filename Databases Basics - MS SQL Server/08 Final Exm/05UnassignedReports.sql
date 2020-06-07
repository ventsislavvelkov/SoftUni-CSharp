SELECT [Description], 
       FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports AS r
     LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
WHERE r.EmployeeId IS NULL
ORDER BY OpenDate, 
         [Description]