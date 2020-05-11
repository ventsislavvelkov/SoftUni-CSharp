CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(10);

	IF(@salary < 30000)
		BEGIN
			SET @salaryLevel = 'Low'
		END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
		BEGIN
			SET @salaryLevel = 'Average'
		END
	ELSE
		BEGIN
			SET @salaryLevel = 'High'
		END
	RETURN @salaryLevel
END

--Executing
GO
SELECT e.Salary,
       dbo.ufn_GetSalaryLevel(e.Salary) AS [Salary Level]
  FROM Employees AS e