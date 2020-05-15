CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
AS
BEGIN TRANSACTION
	    DECLARE @senderAccount INT =
        (
            SELECT Id
              FROM Accounts
             WHERE Id = @SenderId
        );

		DECLARE @receiverAccount INT =
        (
            SELECT Id
              FROM Accounts
             WHERE Id = @ReceiverId
        );

		IF (@senderAccount IS NULL)
		BEGIN
			ROLLBACK;
			RAISERROR('Invalid sender account.', 16, 1);
			RETURN;
		END

		IF (@receiverAccount IS NULL)
		BEGIN
			ROLLBACK;
			RAISERROR('Invalid receiver account.', 16, 2);
			RETURN;
		END;

		IF (@Amount < 0)
		BEGIN
		    ROLLBACK;
			RAISERROR('Amount should be bigeer than zero.', 16, 3);
			RETURN;
		END;

		EXEC dbo.usp_WithdrawMoney @SenderId, @Amount;
		EXEC dbo.usp_DepositMoney @ReceiverId, @Amount;
COMMIT;

--Executing

EXEC usp_TransferMoney 5, 1, 5000