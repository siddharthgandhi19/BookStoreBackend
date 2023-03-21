
CREATE TABLE CART(
CartId INT  IDENTITY(1,1) PRIMARY KEY,
UserId  INT NOT NULL FOREIGN KEY (UserId) REFERENCES UserDetails(UserId),
BookId INT NOT NULL FOREIGN KEY (BookId) REFERENCES Books(BookId),
BookCount INT DEFAULT 1
);