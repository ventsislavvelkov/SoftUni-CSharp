SELECT e.FirstName, 
       e.LastName, 
       e.HireDate, 
       d.[Name] AS DeptName
FROM Employees AS e
     JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
                              AND e.HireDate > '1999-01-01'
WHERE d.[Name] IN('Sales', 'Finance')
ORDER BY e.HireDate