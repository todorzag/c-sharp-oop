USE FurnitureCompany

/*

CREATE TABLE CUSTOMER (
	Customer_ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Customer_Name VARCHAR(40),
	Customer_Address VARCHAR(40),
	Customer_City VARCHAR(30),
	City_Code VARCHAR(4)
)

CREATE TABLE PRODUCT (
	Product_ID INT NOT NULL PRIMARY KEY,
	Product_Desciption VARCHAR(60),
	Product_Finish VARCHAR(20)
	CHECK (Product_Finish IN (
	'череша', 'естествен ясен', 'бял ясен', 
	'червен дъб', 'естествен дъб', 'орех')),
	Standard_Price INT,
	Product_Line_ID INT 
)

CREATE TABLE ORDER_T (
	Order_ID INT NOT NULL PRIMARY KEY,
	Order_Date DATE,
	Customer_ID INT NOT NULL 
	FOREIGN KEY REFERENCES CUSTOMER(Customer_ID)
)

CREATE TABLE ORDER_LINE (
	Order_ID INT NOT NULL 
	FOREIGN KEY REFERENCES ORDER_T(Order_ID),
	Product_ID INT NOT NULL 
	FOREIGN KEY REFERENCES PRODUCT(Product_ID),
	Ordered_Quantity INT
)

insert into CUSTOMER values
('Иван Петров', 'ул. Лавеле 8', 'София', '1000'),
('Камелия Янева', 'ул. Иван Шишман 3', 'Бургас', '8000'),
('Васил Димитров', 'ул. Абаджийска 87', 'Пловдив', '4000'),
('Ани Милева', 'бул. Владислав Варненчик 56', 'Варна','9000');

insert into PRODUCT values
(1000, 'офис бюро', 'череша', 195, 10),
(1001, 'директорско бюро', 'червен дъб', 250, 10),
(2000, 'офис стол', 'череша', 75, 20),
(2001, 'директорски стол', 'естествен дъб', 129, 20),
(3000, 'етажерка за книги', 'естествен ясен', 85, 30),
(4000, 'настолна лампа', 'естествен ясен', 35, 40);

insert into ORDER_T values
(100, '2013-01-05', 1),
(101, '2013-12-07', 2),
(102, '2014-10-03', 3),
(103, '2014-10-08', 2),
(104, '2015-10-05', 1),
(105, '2015-10-05', 4),
(106, '2015-10-06', 2),
(107, '2016-01-06', 1);

insert into ORDER_LINE values
(100, 4000, 1),
(101, 1000, 2),
(101, 2000, 2),
(102, 3000, 1),
(102, 2000, 1),
(106, 4000, 1),
(103, 4000, 1),
(104, 4000, 1),
(105, 4000, 1),
(107, 4000, 1);

SELECT 
PRODUCT.Product_ID,
Product_Desciption,
COUNT(PRODUCT.Product_ID)
FROM PRODUCT
JOIN ORDER_LINE
ON PRODUCT.Product_ID = ORDER_LINE.Product_ID
GROUP BY PRODUCT.Product_ID, Product_Desciption

SELECT 
PRODUCT.Product_ID,
Product_Desciption,
SUM(ISNULL(Ordered_Quantity, 0))
FROM PRODUCT
LEFT JOIN ORDER_LINE
ON PRODUCT.Product_ID = ORDER_LINE.Product_ID
GROUP BY PRODUCT.Product_ID, Product_Desciption

SELECT 
Customer_Name,
SUM(Ordered_Quantity * Standard_Price)
FROM CUSTOMER
JOIN ORDER_T
ON CUSTOMER.Customer_ID = ORDER_T.Customer_ID
JOIN ORDER_LINE
ON ORDER_T.Order_ID = ORDER_LINE.Order_ID
JOIN PRODUCT
ON ORDER_LINE.Product_ID = PRODUCT.Product_ID
GROUP BY Customer_Name

*/