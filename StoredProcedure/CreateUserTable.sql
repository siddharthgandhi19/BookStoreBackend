CREATE DATABASE BookStoreDB

CREATE TABLE UserDetails(
	Id int Identity(1,1) PRIMARY KEY,
	FullName varchar (200),
	Email varchar (100),
	Password varchar(150),
	Mobile varchar(30),
	);

SELECT * FROM UserDetails