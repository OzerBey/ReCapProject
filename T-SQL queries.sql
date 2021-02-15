--for color
CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)
--for brands 
CREATE TABLE Brands(
	BrandId int PRIMARY KEY IDENTITY(1,1),
	BrandName nvarchar(25),
)
--for cars
﻿CREATE TABLE Cars(
	CarId int PRIMARY KEY IDENTITY(1,1),
	BrandId int,
	ColorId int,
	ModelYear nvarchar(25),
	DailyPrice decimal,
	Descriptions nvarchar(25),
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (BrandId) REFERENCES Brands(BrandId)
)

--for users
CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	Password nvarchar(50)
)
--for customer
CREATE TABLE Customers(
	Id int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CompanyName nvarchar(50),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
--for rentals
CREATE TABLE Rentals(
	RentalId int PRIMARY KEY IDENTITY(1,1),
	CarId int,
	CustomerId int,
	RentDate datetime,
	ReturnDate datetime,
	FOREIGN KEY (CarId) REFERENCES Cars(CarId),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id),

)
--datas
--for brands add
INSERT INTO Brands VALUES('Fiat');
INSERT INTO Brands VALUES('Alfa Romeo');
INSERT INTO Brands VALUES('Aston Martin');
INSERT INTO Brands VALUES('Bentley');
INSERT INTO Brands VALUES('Bugatti');
--for colors add
INSERT INTO Colors VALUES('Gray');
INSERT INTO Colors VALUES('Dark Black');
--for cars add
INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions)
VALUES
	('1','2','2012','1000','Sports car'),
	('2','3','2015','1500','Automobile'),
	('2','1','2017','2000','Automatic Hybrid'),
	('3','3','2014','1250','Sedan'),
	('2','3','2014','1250','Company car'),
	('3','3','2014','1250','Passenger car'),
	('1','3','2014','1250','Hatch-back');

-- users datas
INSERT INTO Users VALUES('Yasin','Özer','yasinozeriletisim@gmail.com','ozerbey123');
INSERT INTO Users VALUES('Zeynep','Özer','zeynep@gmail.com','zeynep123');
INSERT INTO Users VALUES('Fahri','Demir','fahri@gmail.com','fahri123');

--customers datas
INSERT INTO Customers VALUES(1,'ZrSoftware');
INSERT INTO Customers VALUES(2,'FlapT3ch');
INSERT INTO Customers VALUES(3,'Kusurat');


-->>check point
	select * from Customers
	select * from Users
	select * from Rentals


