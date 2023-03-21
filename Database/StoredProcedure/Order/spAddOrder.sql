Create or ALTER PROCEDURE spAddOrder
	@UserId INT,
	@AddressId INT,
	@BookId INT ,
	@TotalQuantity INT
AS
	Declare @TotalPrice INT
BEGIN
SELECT @TotalPrice=DiscountPrice FROM BOOKS WHERE BookId = @BookId;
	IF (EXISTS(SELECT * FROM BOOKS WHERE BookId = @BookId))
	BEGIN
		IF (EXISTS(SELECT * FROM UserDetails WHERE UserId = @UserId))
		BEGIN
		BEGIN TRY
			BEGIN TRANSACTION			
				INSERT INTO ORDERTABLE(UserId,AddressId,BookId,Totalprice,TotalQuantity,OrderDate)
				VALUES ( @UserId,@AddressId,@BookId,@TotalQuantity*@TotalPrice,@TotalQuantity,GETDATE())
				Update BOOKS set BookCount=BookCount-@TotalQuantity
				DELETE FROM CART WHERE BookId = @BookId and UserId = @UserId
				SELECT * FROM ORDERTABLE
			COMMIT TRANSACTION
		END TRY
		BEGIN CATCH
			Rollback transaction
		END CATCH
		END
		ELSE
		BEGIN
			SELECT 1
		END
	END 
	ELSE
	BEGIN
			SELECT 2
	END	
END

exec spAddOrder 1,2,1,10