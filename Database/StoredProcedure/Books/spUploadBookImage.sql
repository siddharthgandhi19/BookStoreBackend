CREATE PROCEDURE spUploadBookImage
(
	@BookId INT,
	@BookImage VARCHAR(MAX) 
)
AS BEGIN 
	UPDATE BOOKS SET BookImage = @BookImage WHERE (BookId = @BookId)
END

EXEC spUploadBookImage 1, 'img'

SELECT * FROM BOOKS