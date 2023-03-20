 CREATE PROCEDURE spGetFeedbackById
	@FeedbackId INT
AS
BEGIN
	SELECT 
		FEEDBACKTABLE.FeedbackId,FEEDBACKTABLE.UserId,FEEDBACKTABLE.BookId,FEEDBACKTABLE.Comment,FEEDBACKTABLE.Rating,
		UserDetails.FullName
		FROM UserDetails
		INNER JOIN FeedbackTable
		ON FEEDBACKTABLE.UserId=UserDetails.UserId
		WHERE FeedbackId=@FeedbackId
END