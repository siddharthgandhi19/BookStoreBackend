
------------------------To Insert a User Record------------------------
CREATE PROCEDURE spUserRegistration (
   @FullName varchar (200),
	@Email varchar (100),
	@Mobile varchar(30),
	@Password varchar(150)
  ) as
  Begin
  Insert into UserDetails(FullName,Email,Password, Mobile)         
    Values (@FullName,@Email,@Password, @Mobile) 
  End

  EXEC spUserRegistration @FullName = 'Siddharth Gandhi', @Email = 'siddharth.gandhi@gmail.com',@Password = 'Sid@123456', @Mobile = '7418529630';
  EXEC spUserRegistration @FullName = 'Arpit Jain', @Email = 'arpit.jain@gmail.com',@Password = 'Arp@123456', @Mobile = '7896541230';
  EXEC spUserRegistration @FullName = 'Lalit Raghuwanshi', @Email = 'lalit.raghuwanshi@gmail.com',@Password = 'Lal@123456', @Mobile = '7539518520';
  EXEC spUserRegistration @FullName = 'Samarth Rathore', @Email = 'samarth.rathore@gmail.com',@Password = 'Sam@123456', @Mobile = '9638527410';

