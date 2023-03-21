ALTER PROCEDURE spUpdateAddress
(
	
	@UserId INT,
	@AddressId INT,
	@Address VARCHAR(MAX),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@AddressTypeId INT
)
AS 
BEGIN TRY

UPDATE ADDRESSTABLE SET Address = @Address, City=@City, State=@State, AddressTypeId=@AddressTypeId WHERE
(UserId = @UserId AND AddressId = @AddressId)

END TRY

BEGIN CATCH 
SELECT ERROR_MESSAGE() AS ERROR
END CATCH



