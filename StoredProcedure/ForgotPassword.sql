  CREATE PROCEDURE spForgotPassword(
	@Email varchar (100))
   as
 Begin
	SELECT * FROM UserDetails WHERE Email=@Email
End
