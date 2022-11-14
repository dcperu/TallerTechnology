USE master

GO

CREATE DATABASE CodingAssessment

GO

USE CodingAssessment

GO

CREATE TABLE Customer
(
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Age TINYINT NOT NULL,
	Occupation VARCHAR(50) NULL,
	MaritalStatus VARCHAR(10) NULL,
	PersonId INT IDENTITY PRIMARY KEY NOT NULL
)

GO

CREATE TABLE Orders(
	OrderId INT IDENTITY PRIMARY KEY NOT NULL,
	PersonId INT NOT NULL,
	DateCreated DATE NOT NULL DEFAULT(GETDATE()),
	MethodOfPurchase VARCHAR(10),
	FOREIGN KEY (PersonId) REFERENCES Customer(PersonId)
)


GO

CREATE TABLE OrdersDetail
(
	OrderId INT NOT NULL,
	OrderDetailId INT IDENTITY NOT NULL,
	ProductNumber VARCHAR(10) NOT NULL,
	ProductId INT NOT NULL,
	ProductOrigin VARCHAR(10),
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
	PRIMARY KEY (OrderId,OrderDetailId)
)

GO

DECLARE @newOrderId INT
DECLARE @newCustomerId INT

--First Order
INSERT INTO Customer(FirstName, LastName, Occupation, MaritalStatus, Age) VALUES('John', 'Doe', 'Doctor', 'Married', 40)

SET @newCustomerId = SCOPE_IDENTITY()

INSERT INTO Orders(PersonId, MethodOfPurchase) VALUES(SCOPE_IDENTITY(), 'Online')

SET @newOrderId = SCOPE_IDENTITY()

INSERT INTO OrdersDetail(OrderId, ProductNumber, ProductId, ProductOrigin) VALUES(@newOrderId, 'SKU00001', 1112222333, 'CAN')
INSERT INTO OrdersDetail(OrderId, ProductNumber, ProductId, ProductOrigin) VALUES(@newOrderId, 'SKU00002', 1112222444, 'URU')

--Second Order
INSERT INTO Customer(FirstName, LastName, Occupation, MaritalStatus, Age) VALUES('Sean', 'Doe', 'Administrator', 'Single', 19)

SET @newCustomerId = SCOPE_IDENTITY()

INSERT INTO Orders(PersonId, MethodOfPurchase) VALUES(SCOPE_IDENTITY(), 'Online')

SET @newOrderId = SCOPE_IDENTITY()

INSERT INTO OrdersDetail(OrderId, ProductNumber, ProductId, ProductOrigin) VALUES(@newOrderId, 'SKU00001', 1112222333, 'CAN')
INSERT INTO OrdersDetail(OrderId, ProductNumber, ProductId, ProductOrigin) VALUES(@newOrderId, 'SKU00002', 1112222444, 'URU')

GO

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Full Name], c.Age, o.OrderId, o.DateCreated, o.MethodOfPurchase AS [Purchase Method], od.ProductNumber, od.ProductOrigin 
FROM Orders o 
INNER JOIN OrdersDetail od ON o.OrderId = od.OrderId 
INNER JOIN Customer c ON c.PersonId = o.PersonId
WHERE od.ProductId = '1112222333'