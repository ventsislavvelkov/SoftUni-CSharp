SELECT MIN(a.AverageSalary) AS [MinAverageSalary]
FROM
   (
    SELECT AVG(e.Salary) AS AverageSalary
    FROM Employees AS e
    GROUP BY e.DepartmentID
   ) AS a