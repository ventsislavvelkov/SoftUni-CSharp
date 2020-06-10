CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	 DECLARE @employeeDepartment INT = 
	 (
	   SELECT e.DepartmentId
	     FROM Employees AS e
	 	     JOIN Departments AS d ON e.DepartmentId = d.Id
	    WHERE e.Id = @EmployeeId
	 );
	 
	 DECLARE @reportDepartment INT =
	 (
	   SELECT c.DepartmentId
	     FROM Reports AS r
	 	     JOIN Categories AS c ON r.CategoryId = c.Id
	 	WHERE r.Id = @ReportId
     );
	 
	 IF(@employeeDepartment <> @reportDepartment)
	 BEGIN
	 	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1);
	 	RETURN;
	 END;
	 
	 UPDATE Reports
	    SET EmployeeId = @EmployeeId
	  WHERE Id = @ReportId;
END;

GO

EXEC usp_AssignEmployeeToReport 17, 2
EXEC usp_AssignEmployeeToReport 30, 1