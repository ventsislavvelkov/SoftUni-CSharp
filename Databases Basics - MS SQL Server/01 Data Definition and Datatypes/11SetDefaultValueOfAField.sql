ALTER TABLE Users
ADD DEFAULT GETDATE()
FOR LastLoginTime

INSERT INTO Users(Username, Password, ProfilePicture, IsDeleted) VALUES
('Pesho','123456', 800, 0)