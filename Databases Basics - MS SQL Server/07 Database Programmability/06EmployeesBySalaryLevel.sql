CREATE PROC usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(10))
AS
	SELECT e.FirstName AS [First Name],
	       e.LastName AS [Last Name]
	  FROM Employees AS e
	 WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel

-- Executing
GO

EXEC usp_EmployeesBySalaryLevel 'high'