CREATE TABLE Users
(
  Id BIGINT PRIMARY KEY IDENTITY,
  Username VARCHAR(30) UNIQUE NOT NULL,
  [Password] VARCHAR(26) NOT NULL,
  ProfilePicture VARBINARY(max),
  CHECK(DATALENGTH(ProfilePicture) <= 900000),
  LastLoginTime DATETIME,
  IsDeleted BIT
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho','123456', 800, 2019-12-31, 0),
('Kiro','1234567', 700, 2019-10-15, 1),
('Slavi','slavi123', 900, 2019-04-07, 0),
('Ivan','password1234', 300, 2019-06-30, 1),
('DyNaMiXx7','pass@!kiropeshev', 200, 2019-09-17, 1)