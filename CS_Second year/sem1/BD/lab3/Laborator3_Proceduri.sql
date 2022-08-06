use CarSharing
go

--VERSIUNEA 0->1
CREATE PROCEDURE modifyType
AS
BEGIN
	ALTER TABLE dbo.Adrese
	ALTER COLUMN judet nvarchar(100)
END
GO

CREATE PROCEDURE undoModifyType
AS
BEGIN
	ALTER TABLE dbo.Adrese
	ALTER COLUMN judet varchar(40)
END
GO

--VERSIUNEA 1->2
CREATE PROCEDURE addConstraint
AS
BEGIN
	ALTER TABLE dbo.Rating
	ADD CONSTRAINT default_rating
	DEFAULT 'Insert your rating message here!' FOR rating_msg[dbo].[deleteTable]
END
GO

CREATE PROCEDURE undoAddConstraint
AS
BEGIN
	ALTER TABLE dbo.Rating
	DROP CONSTRAINT default_rating
END 
GO

--VERSIUNEA 2->3
CREATE PROCEDURE addTable
AS
BEGIN
	CREATE TABLE dbo.TestTable(
		TestID INTEGER,
		TestMessage VARCHAR(25),
		TestDate DATE,
		TestRating INTEGER
	);
END
GO

CREATE PROCEDURE undoAddTable
AS
BEGIN
	DROP TABLE dbo.TestTable
END
GO

--VERSIUNEA 3->4
CREATE PROCEDURE addField
AS
BEGIN
	ALTER TABLE dbo.TestTable
	ADD TestLengthMessage BIGINT
END
GO

CREATE PROCEDURE undoAddField
AS
BEGIN
	ALTER TABLE dbo.TestTable
	DROP COLUMN TestLengthMessage
END
GO

--VERSIUNEA 4->5
CREATE PROCEDURE addFK
AS
BEGIN
	ALTER TABLE Tranzactii
	ADD CONSTRAINT FK_PersonOrder
	FOREIGN KEY (id_user) REFERENCES Useri(id_user)
END
GO

CREATE PROCEDURE undoAddFK
AS
BEGIN
	ALTER TABLE Tranzactii
	DROP CONSTRAINT FK_PersonOrder
END
GO

--VERSION CONTROL
CREATE PROCEDURE versionControl
	@wantedVersion tinyint
AS
BEGIN
	DECLARE @vers tinyint
	SET @vers = (SELECT versiune FROM dbo.Versiuni)

	IF(@wantedVersion < 0 OR @wantedVersion > 5) BEGIN
		PRINT('Versiunea trebuie sa fie un numar intre 0 si 5!')
		GOTO SKIPPER
	END

	WHILE(@vers < @wantedVersion)
	BEGIN
		IF(@vers = 0) BEGIN
			EXEC modifyType
			PRINT 'Tipul coloanei judet din tabela Adrese modificat cu succes!'
		END
		IF(@vers = 1) BEGIN
			EXEC addConstraint
			PRINT 'Constrangere default adaugata cu succes pentru coloana rating_msg din tabele Rating!'
		END
		IF(@vers = 2) BEGIN
			EXEC addTable
			PRINT 'Tabela testTabel adaugata cu succes!'
		END
		IF(@vers = 3) BEGIN
			EXEC addField
			PRINT 'Camp TestLengthMessage nou adaugat cu succes in tabela TestTabel!'
		END
		IF(@vers = 4) BEGIN
			EXEC addFK
			PRINT 'Cheia straina adaugata cu succes!'
		END	
		SET @vers = @vers +1;
	END

	WHILE(@vers > @wantedVersion)
	BEGIN
		IF(@vers = 5) BEGIN
			EXEC undoAddFK
			PRINT 'Cheia straina stearsa cu succes!'
		END
		IF(@vers = 4) BEGIN
			EXEC undoAddField
			PRINT 'Camp TestLengthMessage sters cu succes din tabela TestTabel!'
		END
		IF(@vers = 3) BEGIN
			EXEC undoAddTable
			PRINT 'Tabela TestTabel stearsa cu succes!'
		END
		IF(@vers = 2) BEGIN
			EXEC undoAddConstraint
			PRINT 'Constrangere default stearsa cu succes pentru coloana rating_msg din tabele Rating!'
		END
		IF(@vers = 1) BEGIN
			EXEC undoModifyType
			PRINT 'Tipul coloanei judet din tabela Adrese modificat cu succes!'
		END	
		SET @vers = @vers -1;
	END

	IF(@vers = @wantedVersion)
	BEGIN
		PRINT 'Baza de date a fost adusa la versiunea dorita!'
		UPDATE dbo.Versiuni
		SET versiune = @vers
	END

	SKIPPER:
END
GO

drop procedure versionControl

exec versionControl 5

