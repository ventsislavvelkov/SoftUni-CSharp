CREATE PROC usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(15, 4))
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
                RAISERROR('Money amount should be bigger or different from zero.', 16, 2);
                RETURN;
             END;

        UPDATE Accounts
           SET Balance -= @MoneyAmount
         WHERE Accounts.Id = @AccountId;
COMMIT;

--Executing

EXEC usp_WithdrawMoney 5, 25