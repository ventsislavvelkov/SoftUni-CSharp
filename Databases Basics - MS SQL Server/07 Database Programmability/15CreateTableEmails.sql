CREATE TABLE NotificationEmails (
Id INT PRIMARY KEY IDENTITY,
Recipient INT NOT NULL,
[Subject] VARCHAR(100) NOT NULL,
Body VARCHAR(200) NOT NULL,
CONSTRAINT FK_NotificationEmails_Accounts
FOREIGN KEY (Recipient) REFERENCES Accounts(Id)
)



CREATE TRIGGER tr_CreateEmail ON Logs
FOR INSERT
AS
	IF EXISTS
           (
             SELECT *
                  FROM inserted
            )

     INSERT INTO NotificationEmails(Recipient, [Subject], Body)
              SELECT i.AccountId AS [Recipient], 
	             CONCAT('Balance change for account: ', i.AccountId) AS [Subject],
		     CONCAT('On ', GETDATE(), ' your balance was changed from ', i.OldSum, ' to ', i.NewSum) AS [Body]
	      FROM inserted AS i


UPDATE Accounts 
   SET Balance = 100
 WHERE Accounts.Id = 2