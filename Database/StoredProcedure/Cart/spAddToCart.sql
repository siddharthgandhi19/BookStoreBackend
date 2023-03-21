USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[spAddToCart]    Script Date: 21-Mar-23 3:31:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spAddToCart](
	
	@UserId INT,
	@BookId INT,
	@BookCount INT
)
AS 
BEGIN
INSERT INTO CART (UserId,BookId,BookCount)  VALUES ( @UserId,@BookId, @BookCount);
END
