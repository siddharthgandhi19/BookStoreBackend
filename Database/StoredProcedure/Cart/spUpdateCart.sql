CREATE PROCEDURE spUpdateCart(

@CartId INT ,
@BookCount INT
)
AS
BEGIN
UPDATE CART SET BookCount=@BookCount where CartId=@CartId;
END




