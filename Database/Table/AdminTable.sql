CREATE TABLE ADMINTABLE(
	AdminId INT IDENTITY (1,1) PRIMARY KEY,
	AdminName VARCHAR(30),
	Email VARCHAR(30),
	Password VARCHAR(30),
	Mobile BIGINT
);

