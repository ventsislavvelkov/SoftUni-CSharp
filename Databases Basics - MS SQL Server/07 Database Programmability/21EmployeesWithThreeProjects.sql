CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION;
	    DECLARE @employee INT = 
		(
		    SELECT EmployeeID
		      FROM Employees
			 WHERE EmployeeID = @emloyeeId
		);

		DECLARE @project INT = 
		(
		    SELECT ProjectID
		      FROM Projects
			 WHERE ProjectID = @projectID
		);

		IF(@employee IS NULL)
		BEGIN
		     ROLLBACK;
             RAISERROR('Employee Id is invalid.', 16, 2);
             RETURN;
		END;

		IF(@project IS NULL)
		BEGIN
		     ROLLBACK;
             RAISERROR('Project Id is invalid.', 16, 2);
             RETURN;
		END;

		DECLARE @employeesProjectsCount INT = (SELECT COUNT(ep.ProjectID)
		  FROM Employees AS e
		       JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		       WHERE e.EmployeeID = @employee);

		IF (@employeesProjectsCount >= 3)
		BEGIN
			ROLLBACK;
            RAISERROR('The employee has too many projects!', 16, 1);
            RETURN;
		END;

		INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES (@emloyeeId, @projectID)
COMMIT;