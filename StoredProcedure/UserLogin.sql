  CREATE PROCEDURE spUserLogin(
	@Email varchar (100),
	@Password varchar(150)
	)
   as
 Begin
	SELECT * FROM UserDetails WHERE Email=@Email  and Password=@Password
End
