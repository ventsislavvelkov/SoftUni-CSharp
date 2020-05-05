SELECT *
  INTO NewEmployees
  FROM Employees AS e
  WHERE e.Salary > 30000

DELETE FROM NewEmployees
       WHERE ManagerID = 42

UPDATE NewEmployees
   SET Salary += 5000
   WHERE DepartmentID = 1

SELECT ne.DepartmentID,
     AVG (Salary) AS [AverageSalary]
    FROM NewEmployees AS ne
    GROUP BY ne.DepartmentID 