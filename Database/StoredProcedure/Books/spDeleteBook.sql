CREATE PROCEDURE spDeleteBook(
	@BookId INT
)
as
  Begin
 DELETE FROM Books WHERE BookId=@BookId
END

SELECT * FROM BOOKS