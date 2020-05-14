CREATE TABLE Logs (
LogId INT PRIMARY KEY IDENTITY,
AccountId INT NOT NULL,
OldSum DECIMAL(15, 2) NOT NULL,
NewSum DECIMAL(15, 2) NOT NULL,
CONSTRAINT FK_Logs_Accounts
FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)


CREATE TRIGGER tr_SumUpdate ON Accounts
FOR UPDATE
AS
     IF EXISTS
        (
         SELECT *
           FROM inserted
        )
     INSERT INTO Logs(AccountId, OldSum, NewSum)
              SELECT d.Id, 
                     d.Balance, 
                     i.Balance
                FROM deleted AS d
                     INNER JOIN inserted AS i ON i.Id = d.Id;


UPDATE Accounts 
   SET Balance = 113.12
   WHERE Accounts.Id = 1