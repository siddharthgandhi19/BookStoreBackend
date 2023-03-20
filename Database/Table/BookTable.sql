CREATE TABLE BOOKS(
BookId INT IDENTITY(1,1) PRIMARY KEY,
BookName VARCHAR (500),
AuthorName VARCHAR(20),
Rating VARCHAR(300),
TotalCountRating INT,
DiscountPrice INT,
OriginalPrice INT,
Description VARCHAR (500),
BookImage VARCHAR (200),
BookCount INT NOT NULL
);

SELECT * FROM BOOKS