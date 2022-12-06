BEGIN TRY
BEGIN TRANSACTION CreateNewSddSchemaTableColumns

	/*** application table ***/
	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BApplication'
		AND COLUMN_NAME = 'DynamicsApplicationId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BApplication]
		ADD	DynamicsApplicationId uniqueidentifier NULL
	END

	/*** [sdd].[A2BApplicationApplyingSchool] school table ***/
	--urn && LA name
	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BApplicationApplyingSchool'
		AND COLUMN_NAME = 'DynamicsApplyingSchoolId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BApplicationApplyingSchool]
		ADD	DynamicsApplyingSchoolId uniqueidentifier NULL,
			Urn int NULL,
			LocalAuthorityName nvarchar(max) NULL
	END

	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BApplicationApplyingSchool'
		AND COLUMN_NAME = 'DynamicsApplicationId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BApplicationApplyingSchool]
		ADD	DynamicsApplicationId uniqueidentifier NULL
	END

	/*** [sdd].[A2BApplicationKeyPersons] ***/
	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BApplicationKeyPersons'
		AND COLUMN_NAME = 'DynamicsKeyPersonId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BApplicationKeyPersons]
		ADD	DynamicsKeyPersonId uniqueidentifier NULL
	END

	/*** [sdd].[A2BSchoolLease] ***/
	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BSchoolLease'
		AND COLUMN_NAME = 'DynamicsSchoolLeaseId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BSchoolLease]
		ADD	DynamicsSchoolLeaseId uniqueidentifier NULL
	END

	/*** [sdd].[A2BSchoolLoan] ***/
	IF NOT EXISTS
	(
		SELECT *
		FROM INFORMATION_SCHEMA.COLUMNS
		WHERE TABLE_SCHEMA = 'sdd'
		AND TABLE_NAME = 'A2BSchoolLoan'
		AND COLUMN_NAME = 'DynamicsSchoolLoanId'
	)
	BEGIN
		ALTER TABLE [sdd].[A2BSchoolLoan]
		ADD	DynamicsSchoolLoanId uniqueidentifier NULL
	END

	COMMIT TRAN CreateNewSddSchemaTableColumns
	--ROLLBACK TRAN CreateNewSddSchemaTableColumns

END TRY
BEGIN CATCH
  SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_SEVERITY() AS ErrorSeverity,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;

-- Transaction uncommittable
    IF (XACT_STATE()) = -1
      ROLLBACK TRANSACTION
 
-- Transaction committable
    IF (XACT_STATE()) = 1
      COMMIT TRANSACTION
END CATCH;
GO
