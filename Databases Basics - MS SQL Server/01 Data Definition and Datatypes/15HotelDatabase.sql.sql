CREATE TABLE Employees (
  Id INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  Title NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE Customers (
  AccountNumber INT PRIMARY KEY IDENTITY,
  FirstName NVARCHAR(30) NOT NULL,
  LastName NVARCHAR(30) NOT NULL,
  PhoneNumber VARCHAR(15) NOT NULL,
  EmergencyName NVARCHAR(50) NOT NULL,
  EmergencyNumber VARCHAR(15) NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE RoomStatus (
  RoomStatus NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE RoomTypes (
  RoomType NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE BedTypes (
  BedType NVARCHAR(30) PRIMARY KEY NOT NULL,
  Notes NVARCHAR(max)
)

CREATE TABLE Rooms (
  RoomNumber INT PRIMARY KEY IDENTITY,
  RoomType NVARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType),
  BedType NVARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType),
  Rate DECIMAL(3, 2) NOT NULL,
  RoomStatus NVARCHAR(30) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
  Notes NVARCHAR(max)
)

CREATE TABLE Payments (
  Id INT PRIMARY KEY IDENTITY,
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
  PaymentDate DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
  FirstDateOccupied DATE NOT NULL,
  LastDateOccupied DATE NOT NULL,
  TotalDays INT NOT NULL,
  AmountCharged DECIMAL(15, 2) NOT NULL,
  TaxRate DECIMAL(4, 2) NOT NULL,
  TaxAmount DECIMAL(15, 2) NOT NULL,
  PaymentTotal DECIMAL(15, 2) NOT NULL,
  Notes NVARCHAR(max),
  CHECK(TotalDays = DATEDIFF(day, FirstDateOccupied, LastDateOccupied) + 1)
)

CREATE TABLE Occupancies (
  Id INT PRIMARY KEY IDENTITY,
  EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
  DateOccupied DATE NOT NULL,
  AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
  RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
  RateApplied DECIMAL(4, 2) NOT NULL,
  PhoneCharge DECIMAL(5, 2) NOT NULL,
  Notes NVARCHAR(max)
)

INSERT INTO Employees(FirstName, LastName, Title, Notes) VALUES
('Stanislav', 'Stoyanov', 'Sir', 'Some text here'),
('Pesho', 'Peshev', 'Sir', 'Some text here, etc'),
('Maria', 'Dimitrov', 'Madam', 'Some text here and so on')

INSERT INTO Customers(FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
('Kiril', 'Petrov', '0884034666', 'OZK', '112', 'Some text here'),
('Stamat', 'Stamatov', '0884034321', 'Pesho', '112', 'Some text here, etc'),
('Dimitrina', 'Hristova', '0884034123', 'Kiro', '112', 'Some text here and so on')

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
(1, 'Some text here'),
(2, 'Some text here and so on'),
(3, 'Example')

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Luxury double room', 'Some text here and so on'),
('Studio', 'Some text here'),
('Double room', 'Some text here, etc')

INSERT INTO BedTypes(BedType, Notes) VALUES
('2 legla', 'Some text here'),
('3 legla', 'Some text here, etc'),
('1 leglo', 'Malka staq prosto')

INSERT INTO Rooms(RoomType, BedType, Rate, RoomStatus, Notes) VALUES
('Luxury double room', '2 legla', 4.50, 1, 'Some text here'),
('Studio', '3 legla', 5.50, 1, 'Some text here, etc'),
('Double room', '1 leglo', 5.70, 1, 'Some text here and so on')

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, '2018-06-30', 1, '2018-03-10', '2018-03-11', 2, 315, 95.5, 127, 668, 'Too expensive'),
(2, '2019-06-30', 2, '2019-03-10', '2019-03-12', 3, 215, 90.5, 107, 550, 'Better price'),
(3, '2017-06-30', 3, '2019-03-10', '2019-03-10', 1, 115, 70.5, 87, 338, 'Perfect price')

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, '2019-06-30', 1, 1, 14.75, 20.20, 'Some text here'),
(2, '2019-03-15', 2, 2, 10.5, 10.50, 'Some text here, etc'),
(3, '2019-02-10', 3, 3, 9.80, 8.30, '')