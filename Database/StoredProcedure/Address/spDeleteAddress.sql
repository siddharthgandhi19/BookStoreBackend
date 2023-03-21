CREATE PROCEDURE spDeleteAddress
(
	@AddressId INT
)
AS BEGIN
	BEGIN TRY
		IF EXISTS(SELECT * FROM ADDRESSTABLE WHERE(AddressId= @AddressId))
		BEGIN
			DELETE ADDRESSTABLE WHERE(AddressId= @AddressId)
		END
	END TRY
	BEGIN CATCH
		SELECT ERROR_MESSAGE() AS ERROR
	END CATCH
END
