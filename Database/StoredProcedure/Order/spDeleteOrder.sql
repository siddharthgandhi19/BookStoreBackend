CREATE or ALTER PROCEDURE spDeleteOrder
		@OrderId INT
AS
	BEGIN
	DECLARE @OrderQuantity INT = (SELECT TotalQuantity FROM ORDERTABLE WHERE OrderId = @OrderId)
	DECLARE @BookId INT = (SELECT BookId FROM ORDERTABLE WHERE OrderId = @OrderId)
		BEGIN
			UPDATE CART
			SET BookCount = BookCount + @OrderQuantity
			WHERE BookId = @BookId
		END
		BEGIN
			DELETE FROM ORDERTABLE
			WHERE OrderId = @OrderId
		END
	END

	
