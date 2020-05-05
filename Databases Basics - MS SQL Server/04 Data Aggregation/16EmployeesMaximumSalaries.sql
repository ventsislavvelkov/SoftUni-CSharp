SELECT DepartmentID, MAX (Salary) AS [MaxSalary]
     FROM Employees AS e
     GROUP BY e.DepartmentID
     HAVING MAX (Salary) NOT BETWEEN 30000 AND 70000