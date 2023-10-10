-- SQLite
DROP TABLE IF EXISTS `customer`;
DROP TABLE IF EXISTS `user`;	

CREATE TABLE IF NOT EXISTS `customer` (
  `CustomerID` TEXT PRIMARY KEY,
  `CompanyName` TEXT NOT NULL,
  `ContactName` TEXT NOT NULL,
  `ContactTitle` TEXT NOT NULL,
  `Address` TEXT NOT NULL,
  `City` TEXT NOT NULL,
  `Region` TEXT NOT NULL,
  `PostalCode` TEXT NOT NULL,
  `Country` TEXT NOT NULL,
  `Phone` TEXT NOT NULL,
  `Fax` TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS `user` (
  `UserID` TEXT PRIMARY KEY,
  `FirstName` TEXT NOT NULL,
  `LastName` TEXT NOT NULL,
  `UserName` TEXT NOT NULL,
  `Password` TEXT NOT NULL
);

INSERT INTO `customer` (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('ALFKI','Alfreds Futterkiste','Maria Anders','Sales Representative','Obere Str. 57','Berlin','','12209','Germany','030-0074321','030-0076545');
INSERT INTO `customer` (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('ANATR','Ana Trujillo Emparedados y helados','Ana Trujillo','Owner','Avda. de la Constitución 2222','México D.F.','','05021','Mexico','(5) 555-4729','(5) 555-3745');
INSERT INTO `customer` (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('ANTON','Antonio Moreno Taquería','Antonio Moreno','Owner','Mataderos  2312','México D.F.','','05023','Mexico','(5) 555-3932','');
INSERT INTO `customer` (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) VALUES('AROUT','Around the Horn','Thomas Hardy','Sales Representative','120 Hanover Sq.','London','','WA1 1DP','UK','(171) 555-7788','(171) 555-6750');

INSERT INTO `user` (UserID, FirstName, LastName, UserName, Password) VALUES('1','John','Doe','johndoe','123456');
INSERT INTO `user` (UserID, FirstName, LastName, UserName, Password) VALUES('2','Jane','Doe','janedoe','123456');
INSERT INTO `user` (UserID, FirstName, LastName, UserName, Password) VALUES('3','John','Smith','johnsmith','123456');
INSERT INTO `user` (UserID, FirstName, LastName, UserName, Password) VALUES('4','Jane','Smith','janesmith','123456');