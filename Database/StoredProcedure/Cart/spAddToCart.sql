CREATE PROCEDURE spAddToCart(
	
	@BookId INT,
	@UserId INT,
	@Quantity INT
)
AS 
BEGIN
INSERT INTO CART (BookId,UserId,Quantity)  VALUES (@BookId, @Quantity, @UserId);
END