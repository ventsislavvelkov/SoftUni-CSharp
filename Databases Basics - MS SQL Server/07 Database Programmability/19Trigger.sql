CREATE TRIGGER tr_ItemsInsert ON Items 
AFTER INSERT
AS
	IF (EXISTS ( SELECT *
				   FROM inserted
				   JOIN UserGameItems AS ugi ON ugi.UserGameId = inserted.Id
				   JOIN UsersGames AS ug ON ug.Id = ugi.ItemId
				  WHERE inserted.[MinLevel] > ug.[Level])
	   )
	BEGIN
		ROLLBACK;
		RAISERROR('Users should not buy items with higher level than their level.', 16, 1);
        RETURN;
	END;

	UPDATE UsersGames
	   SET Cash += 50000
	  FROM UsersGames AS ug
		   JOIN Users AS u ON u.Id = ug.UserId
		   JOIN Games AS g ON ug.GameId = g.Id
	 WHERE u.[Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
	   AND g.[Name] = 'Bali'

	UPDATE UsersGames
	   SET Cash -= i.Price
	  FROM UsersGames AS ug
	       JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
		   JOIN Items AS i ON i.Id = ugi.ItemId
	 WHERE (i.Id BETWEEN 251 AND 299) AND (i.Id BETWEEN 501 AND 539)

	 SELECT u.[Username],
	        g.[Name],
			ug.[Cash],
			i.[Name] AS [Item Name]
	   FROM Users AS u
	         JOIN UsersGames AS ug ON u.Id = ug.UserId
			 JOIN Games AS g ON g.Id = ug.GameId
			 JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
			 JOIN Items AS i ON i.Id = ugi.ItemId
	  WHERE g.[Name] = 'Bali'
   ORDER BY u.[Username], i.[Name]