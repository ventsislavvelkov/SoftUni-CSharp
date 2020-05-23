CREATE TABLE Deleted_Employees (
EmployeeId INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(50),
JobTitle NVARCHAR(30) NOT NULL,
DepartmentId INT NOT NULL,  
Salary DECIMAL(15, 4) NOT NULL
)


CREATE TRIGGER tr_EmployeesDelete ON Employees
FOR DELETE
AS
     BEGIN
         INSERT INTO Deleted_Employees
         (FirstName, 
          LastName, 
          MiddleName, 
          JobTitle, 
          DepartmentId, 
          Salary
         )
              SELECT d.FirstName, 
                     d.LastName, 
                     d.MiddleName, 
                     d.JobTitle, 
                     d.DepartmentID, 
                     d.Salary
              FROM deleted AS d;
     END;


DELETE FROM Employees WHERE EmployeeID = 292