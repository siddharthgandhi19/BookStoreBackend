CREATE PROCEDURE spGetWishList
@UserId INT
AS
BEGIN TRY
SELECT WishListId,UserId,b.BookId,b.BookName,b.AuthorName,b.OriginalPrice, b.DiscountPrice, b.BookImage from WishListTable 
c join BOOKS b on c.BookId=b.BookId 
WHERE UserId=@UserId;
END TRY
BEGIN CATCH
SELECT ERROR_MESSAGE() AS ERROR
END CATCH
