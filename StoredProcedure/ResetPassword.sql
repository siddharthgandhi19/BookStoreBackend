CREATE PROCEDURE spResetPassword
@Email varchar(50),
@Password varchar(100)
AS
BEGIN
	Update UserDetails Set Password=@Password where Email=@Email
END