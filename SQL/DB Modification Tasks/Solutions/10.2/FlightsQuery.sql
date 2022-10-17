USE CUSTOM_BASE_2
GO

CREATE TABLE AIRLINE (
	CODE VARCHAR(2) NOT NULL PRIMARY KEY,
	NAME VARCHAR(60) UNIQUE,
	COUNTRY VARCHAR(40)
)

CREATE TABLE AIRPORT (
	CODE VARCHAR(3) NOT NULL PRIMARY KEY,
	NAME VARCHAR(60) UNIQUE,
	COUNTRY VARCHAR(40),
	CITY VARCHAR(40),
)

CREATE TABLE AIRPLANE (
	CODE VARCHAR(3) NOT NULL PRIMARY KEY,
	TYPE VARCHAR(30),
	SEATS INT CHECK (SEATS > 0),
	YEAR INT
)

CREATE TABLE FLIGHT (
	FNUMBER VARCHAR(6) NOT NULL PRIMARY KEY,
	AIRLINE_OPERATOR VARCHAR(2)
	FOREIGN KEY REFERENCES AIRLINE(CODE),
	DEP_AIRPORT VARCHAR(3)
	FOREIGN KEY REFERENCES AIRPORT(CODE),
	ARR_AIRPORT VARCHAR(3)
	FOREIGN KEY REFERENCES AIRPORT(CODE),
	FLIGHT_TIME VARCHAR(5),
	FLIGHT_DURATION INT,
	AIRPLANE VARCHAR(3)
	FOREIGN KEY REFERENCES AIRPLANE(CODE)
)

CREATE TABLE CUSTOMER (
	ID INT NOT NULL PRIMARY KEY,
	FNAME VARCHAR(20),
	LNAME VARCHAR(20),
	EMAIL VARCHAR(40) CHECK (EMAIL LIKE '%@%.%' AND LEN(EMAIL)>= 6),
)

CREATE TABLE AGENCY (
	NAME VARCHAR(20) NOT NULL PRIMARY KEY,
	COUNTRY VARCHAR(30),
	CITY VARCHAR(30),
	PHONE VARCHAR(15)
)

CREATE TABLE BOOKING (
	CODE VARCHAR(6) NOT NULL PRIMARY KEY,
	AGENCY VARCHAR(20)
	FOREIGN KEY REFERENCES AGENCY(NAME),
	AIRLINE_CODE VARCHAR(2)
	FOREIGN KEY REFERENCES AIRLINE(CODE),
	FLIGHT_NUMBER VARCHAR(6)
	FOREIGN KEY REFERENCES FLIGHT(FNUMBER),
	CUSTOMER_ID INT
	FOREIGN KEY REFERENCES CUSTOMER(ID),
	BOOKING_DATE DATE,
	FLIGHT_DATE DATE,
	CHECK (FLIGHT_DATE >= BOOKING_DATE),
	PRICE INT,
	STATUS INT CHECK (STATUS IN (0, 1))
)

INSERT INTO AIRLINE
VALUES ('AZ', 'Alitalia', 'Italy'),
('BA', 'British Airways', 'United Kingdom'),
('LH', 'Lufthansa', 'Germany'),
('SR', 'Swissair', 'Switzerland'),
('FB', 'Bulgaria Air', 'Bulgaria'),
('AF', 'Air France', 'France'),
('TK', 'Turkish Airlines', 'Turkey'),
('AA', 'American Airlines', 'United States');

INSERT INTO AIRPORT
VALUES ('SOF', 'Sofia International', 'Bulgaria', 'Sofia'),
('CDG', 'Charles De Gaulle', 'France', 'Paris'),
('ORY', 'Orly', 'France', 'Paris'),
('LBG', 'Le Bourget', 'France', 'Paris'),
('JFK', 'John F Kennedy International', 'United States', 'New York'),
('ORD', 'Chicago O''Hare International', 'United States', 'Chicago'),
('FCO', 'Leonardo da Vinci International', 'Italy', 'Rome'),
('LHR', 'London Heathrow', 'United Kingdom', 'London');

INSERT INTO AIRPLANE
VALUES ('319', 'Airbus A319', 150, 1993),
('320', 'Airbus A320', 280, 1984),
('321', 'Airbus A321', 150, 1989),
('100', 'Fokker 100', 80, 1991),
('738', 'Boeing 737-800', 90, 1997),
('735', 'Boeing 737-800', 90, 1995);

INSERT INTO FLIGHT
VALUES ('FB1363', 'AZ', 'SOF', 'ORY', '12:45', 100, '738'),
('FB1364', 'AZ', 'CDG', 'SOF', '10:00', 120, '321'),
('SU2060', 'AZ', 'LBG', 'SOF', '11:10', 110, '738'),
('SU2061', 'TK', 'SOF', 'JFK', '13:00', 110, '320'),
('FB363', 'FB', 'SOF', 'ORD', '15:10', 110, '738'),
('FB364', 'FB', 'LHR', 'SOF', '21:05', 120, '738');

INSERT INTO CUSTOMER
VALUES (1, 'Petar', 'Milenov', 'petter@mail.com'),
(2, 'Dimitar', 'Petrov', 'petrov@mail.com'),
(3, 'Ivan', 'Ivanov', 'ivanov@mail.com'),
(4, 'Petar', 'Slavov', 'slavov@mail.com'),
(5, 'Bogdan', 'Bobov', 'bobov@mail.com');

INSERT INTO AGENCY
VALUES ('Travel One', 'Bulgaria', 'Sofia', '0783482233'),
('Travel Two', 'Bulgaria', 'Plovdiv', '02882234'),
('Travel Tour', 'Bulgaria', 'Sofia', NULL),
('Aerotravel', 'Bulgaria', 'Varna', '02884233');

INSERT INTO BOOKING
VALUES ('YN298P', 'Travel One', 'FB', 'FB1363', 1, '2013-11-18', '2013-12-25', 300, 0),
('YA298P', 'Travel Two', 'FB', 'FB1364', 2, '2013-12-18', '2013-12-25', 300, 1),
('YB298P', 'Travel Tour', 'FB', 'SU2060', 3, '2014-01-18', '2014-02-25', 400, 0),
('YC298P', 'Travel One', 'FB', 'SU2061', 4, '2014-11-11', '2014-11-25', 350, 0),
('YD298P', 'Travel Tour', 'FB', 'FB363', 1, '2013-11-03', '2013-12-20', 250, 1),
('YE298P', 'Aerotravel', 'FB', 'FB364', 2, '2013-11-07', '2013-12-21', 150, 0);