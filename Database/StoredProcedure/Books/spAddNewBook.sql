CREATE PROCEDURE spAddNewBook(
 @BookName VARCHAR (500),
 @AuthorName VARCHAR(20),
 @Rating VARCHAR(300),
 @TotalCountRating INT,
 @DiscountPrice INT,
 @OriginalPrice INT,
 @Description VARCHAR (500),
 @BookImage VARCHAR (200),
 @BookCount INT 
)
as
  Begin
  Insert into BOOKS Values (@BookName,@AuthorName,@Rating, @TotalCountRating,@DiscountPrice,@OriginalPrice,@Description,@BookImage,@BookCount) 
  End

  EXEC spAddNewBook Doglapan, "Ashneer Grover", "4.5", 60,250,500,"The Hard Truth about Life and Startups","string",50;
  SELECT * FROM BOOKS
