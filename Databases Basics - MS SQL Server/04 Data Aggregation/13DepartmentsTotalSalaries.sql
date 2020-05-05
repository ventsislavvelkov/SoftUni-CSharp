 SELECT e.DepartmentID, SUM (Salary) AS [TotalSalary]
    FROM Employees AS e
    GROUP BY e.DepartmentID
    ORDER BY e.DepartmentID