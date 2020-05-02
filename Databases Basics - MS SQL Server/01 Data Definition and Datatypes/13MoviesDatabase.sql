CREATE TABLE Directors (
  Id INT PRIMARY KEY IDENTITY,
  DirectorName NVARCHAR(30) NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE Genres (
  Id INT PRIMARY KEY IDENTITY,
  GenreName NVARCHAR(30) NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE Categories (
  Id INT PRIMARY KEY IDENTITY,
  CategoryName NVARCHAR(30) NOT NULL,
  Notes NVARCHAR(max)
)


CREATE TABLE Movies (
  Id INT PRIMARY KEY IDENTITY,
  Title NVARCHAR(40) NOT NULL,
  DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
  CopyrightYear INT NOT NULL,
  [Length] INT NOT NULL,
  GenreId INT FOREIGN KEY REFERENCES Genres(Id),
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
  Rating DECIMAL(2, 1) NOT NULL,
  Notes NVARCHAR(max)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Pesho', 'Hello, my name is Pesho'),
('Kiro', 'Hello, my name is Kiro'),
('Slavi', 'Hello, my name is Slavi'),
('Stefan', 'Hello, my name is Stefan'),
('Maria', 'Hello, my name is Maria')

INSERT INTO Genres(GenreName, Notes) VALUES
('Action', 'Action movie'),
('Comedy', 'Comedy movie'),
('Drama', 'Drama movie'),
('Animation', 'Animation movie'),
('Adventure', 'Adventure movie')

INSERT INTO Categories(CategoryName, Notes) VALUES
('Films by character‎', 'Some notes here'),
('Films by city‎', 'Some notes here'),
('Films by country‎', 'Some notes here'),
('Films by language‎', 'Some notes here'),
('Films by date‎', '')

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) Values
('Titanik', 1, 2001, 220, 3, 1, 5.50, 'Some text here'),
('Fast and Furious', 2, 1999, 137, 2, 2, 6, 'Some text here'),
('Bozata', 3, 2010, 87, 4, 3, 4.50, 'Some text here'),
('Lord of rings', 4, 2013, 150, 3, 3, 3.50, 'Some text here and so on'),
('Titanik 2', 1, 2001, 200, 4, 4, 5.75, 'Some text here, etc')