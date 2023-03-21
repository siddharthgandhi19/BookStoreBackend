CREATE PROCEDURE spAddAddress
(
	@Address VARCHAR(MAX),
	@City VARCHAR(100),
	@State VARCHAR(100),
	@AddressTypeId INT,
	@UserId INT
	
)
AS 
BEGIN TRY

INSERT INTO ADDRESSTABLE (Address,City,State,AddressTypeId,UserId) values(@Address,@City,@State,@AddressTypeId,@UserId)

END TRY

BEGIN CATCH 
SELECT ERROR_MESSAGE() AS ERROR
END CATCH

