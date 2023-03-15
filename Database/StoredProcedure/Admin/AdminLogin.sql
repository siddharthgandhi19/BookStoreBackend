CREATE PROCEDURE spAdminLogin(
@Email VARCHAR(50),
@Password VARCHAR(50)
)
as
 Begin
	SELECT * FROM ADMINTABLE WHERE Email=@Email  and Password=@Password
End

