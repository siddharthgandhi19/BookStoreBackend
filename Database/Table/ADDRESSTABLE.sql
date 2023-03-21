CREATE TABLE ADDRESSTYPE
( 
	AddressTypeId INT PRIMARY KEY IDENTITY NOT NULL, 
	AddressType VARCHAR(max)
)
INSERT INTO ADDRESSTYPE VALUES ('WORK'),('Home'),('Others');



CREATE TABLE ADDRESSTABLE
(	AddressId INT PRIMARY KEY IDENTITY NOT NULL,
	UserId INT FOREIGN KEY (UserId) REFERENCES UserDetails(UserId),
	AddressTypeId INT FOREIGN KEY (AddressTypeId) REFERENCES ADDRESSTYPE(AddressTypeId),
	Address VARCHAR(MAX),
	City VARCHAR(100),
	State VARCHAR(100)
);

