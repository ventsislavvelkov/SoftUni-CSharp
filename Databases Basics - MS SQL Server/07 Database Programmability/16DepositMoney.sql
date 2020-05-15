CREATE PROC usp_DepositMoney(@AccountId INT, @MoneyAmount DECIMAL(15, 4))
AS
BEGIN TRANSACTION;
		DECLARE @account INT = 
		(
		    SELECT Id 
		      FROM Accounts
			 WHERE Id = @AccountId
		);

		IF(@account IS NULL)
            BEGIN
                ROLLBACK;
                RAISERROR('Account Id is invalid.', 16, 1);
                RETURN;
             END;

        IF(@MoneyAmount < 0)
            BEGIN
                ROLLBACK;
                RAISERROR('Money should be positive.', 16, 2);
                RETURN;
             END;

        UPDATE Accounts
           SET Balance += @MoneyAmount
         WHERE Accounts.Id = @AccountId;
COMMIT;

--Executing

EXEC usp_DepositMoney 1, 10