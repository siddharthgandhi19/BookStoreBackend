CREATE PROCEDURE spUpdateCart(

@CartId INT ,
@Quantity INT
)
AS
BEGIN
UPDATE CART SET Quantity=@Quantity where CartId=@CartId;
END




