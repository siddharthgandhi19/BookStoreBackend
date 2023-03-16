CREATE PROCEDURE spUpdateBook(
 @BookId INT,
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

AS
BEGIN
UPDATE BOOKS SET BookName=@BookName,AuthorName=AuthorName,Rating=@Rating,TotalCountRating=@TotalCountRating,DiscountPrice=@DiscountPrice,
OriginalPrice=@OriginalPrice,Description=@Description,BookImage=@BookImage,BookCount=@BookCount WHERE BookId=@BookId;
END

