SELECT e.EmployeeID, 
       e.FirstName, 
       IIF((DATEPART(YEAR, p.StartDate)) >= 2005, NULL, p.[Name]) AS ProjectName
FROM Employees AS e
     JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
     JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE ep.EmployeeID = 24