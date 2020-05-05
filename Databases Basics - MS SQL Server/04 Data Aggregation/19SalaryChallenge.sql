SELECT TOP(10) FirstName, LastName, DepartmentID
      FROM     Employees AS e
      WHERE    Salary  (SELECT AVG(Salary) 
                           FROM Employees AS em
		           WHERE em.DepartmentID = e.DepartmentID)
      ORDER BY  DepartmentID