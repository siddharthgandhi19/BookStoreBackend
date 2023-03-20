CREATE Table FEEDBACKTABLE
( FeedbackId INT IDENTITY(1,1) PRIMARY KEY, Rating VARCHAR, Comment VARCHAR(max), 
UserId INT FOREIGN KEY (UserId) references UserDetails(UserId),
BookId INT FOREIGN KEY (BookId) references BOOKS(BookId)
)



