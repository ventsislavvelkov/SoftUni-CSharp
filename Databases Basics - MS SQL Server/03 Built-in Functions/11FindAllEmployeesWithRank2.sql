         WITH Employee_CTE AS 
		  (SELECT EmployeeID,
                  FirstName,
	              LastName,
	              Salary,
DENSE_RANK() OVER (
	PARTITION  BY Salary
	     ORDER BY EmployeeID
		          )
	              [Rank]
	         FROM Employees
		  )
		   SELECT *
		     FROM Employee_CTE
			WHERE (Salary BETWEEN 10000 AND 50000) AND [Rank] = 2
		 ORDER BY Salary 
		     DESC