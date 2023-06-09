USE [BookStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[spAddFeedback]    Script Date: 20-Mar-23 4:18:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spAddFeedback]
( 
  @Rating VARCHAR, @Comment VARCHAR(max), @UserId INT, @BookId INT
)
AS
BEGIN TRY
INSERT INTO FEEDBACKTABLE(Rating, Comment, UserId, BookId) VALUES ( @Rating,@Comment, @UserId, @BookId);
END TRY
BEGIN CATCH
 SELECT ERROR_MESSAGE() AS ERROR
END CATCH