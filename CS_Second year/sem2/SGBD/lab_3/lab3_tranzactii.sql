go
use CarSharing
go

CREATE TABLE LogTable(
Lid INT IDENTITY PRIMARY KEY,
TypeOperation VARCHAR(50),
TableOperation VARCHAR(50),
ExecutionDate DATETIME)

--validare zonă
GO
CREATE OR ALTER FUNCTION VALIDARE_ZONE(@nume VARCHAR(1000) , @oras VARCHAR(1000))
RETURNS VARCHAR(1500) AS
BEGIN
		DECLARE @msg_eroare VARCHAR(1500);
		SET @msg_eroare = '';
		IF (@nume LIKE '%[0-9!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Numele zonei trebuie sa contina doar litere!,'
		END
		IF (@oras LIKE '%[0-9!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Numele orasului trebuie sa contina doar litere!,'
		END
		IF LEN(@nume) > 30 OR LEN(@nume) < 1 SET @msg_eroare = @msg_eroare + 'Dimensiunea numelui zonei trebuie sa fie intre 1 si 30 de caractere!,'
		IF LEN(@oras) > 30 OR LEN(@oras) < 1 SET @msg_eroare = @msg_eroare  + 'Dimensiunea numelui orasului trebuie sa fie intre 1 si 30 de caractere!,'

		SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
		RETURN @msg_eroare;
END
GO

--validare sofer
GO
CREATE OR ALTER FUNCTION VALIDARE_SOFER(@nume VARCHAR(1000) , @prenume VARCHAR(1000), @telefon VARCHAR(1000))
RETURNS VARCHAR(1500) AS
BEGIN
		DECLARE @msg_eroare VARCHAR(1500);
		SET @msg_eroare = '';
		IF (@nume LIKE '%[0-9!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Numele trebuie sa contina doar litere!,'
		END
		IF (@prenume LIKE '%[0-9!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Prenumele trebuie sa contina doar litere!,'
		END
		IF LEN(@nume) > 30 OR LEN(@nume) < 1 SET @msg_eroare = @msg_eroare + 'Dimensiunea numelui trebuie sa fie intre 1 si 30 de caractere!,'
		IF LEN(@prenume) > 30 OR LEN(@prenume) < 1 SET @msg_eroare = @msg_eroare  + 'Dimensiunea prenumelui trebuie sa fie intre 1 si 30 de caractere!,'
		IF (@telefon LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Telefonul trebuie sa contina doar cifre!,'
		END
		IF LEN(@telefon) < 10 OR LEN(@telefon) > 10 SET @msg_eroare = @msg_eroare  + 'Dimensiunea numarului de telefon trebuie sa fie de exact 10 caractere!,'

		SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
		RETURN @msg_eroare;
END
GO

--ne returneaza urmatorul id din tabela 'Zone'
GO 
CREATE OR ALTER FUNCTION get_next_id_zona()
RETURNS INT
AS
BEGIN
	DECLARE @id INT
	SET @id = 0
	SELECT TOP 1 @id = id_zona FROM Zone ORDER BY id_zona DESC
	SET @id = @id + 1;
	RETURN @id
END
GO

--ne returneaza urmatorul id din tabela 'Soferi'
GO 
CREATE OR ALTER FUNCTION get_next_id_sofer()
RETURNS INT
AS
BEGIN
	DECLARE @id INT
	SET @id = 0
	SELECT TOP 1 @id = id_sofer FROM Soferi ORDER BY id_sofer DESC
	SET @id = @id + 1;
	RETURN @id
END
GO


--Creaþi o procedurã stocatã ce insereazã date pentru entitãþi ce se aflã într-o relaþie m-n. 
--Dacã o operaþie de inserare eºueazã, trebuie fãcut roll-back pe întreaga procedurã stocatã.
GO
CREATE OR ALTER PROCEDURE insert_with_total_rollback @nume_zona VARCHAR(30), @nume_oras VARCHAR(30), @nume_sofer VARCHAR(30), @prenume_sofer VARCHAR(30), @telefon_sofer VARCHAR(30)
AS
BEGIN
	BEGIN TRAN
		BEGIN TRY
			--INSERT in Accesorii
			DECLARE @msg_eroare_zone VARCHAR(1500)
			DECLARE @msg_eroare_soferi VARCHAR(1500)
			SET @msg_eroare_zone = dbo.VALIDARE_ZONE(@nume_zona, @nume_oras)
			SET @msg_eroare_soferi = dbo.VALIDARE_SOFER(@nume_sofer, @prenume_sofer, @telefon_sofer)
			IF (LEN(@msg_eroare_zone) > 0 OR LEN(@msg_eroare_soferi) > 0)
			BEGIN 
			    DECLARE @msg_eroare VARCHAR(5000)
				SET @msg_eroare = @msg_eroare_zone + @msg_eroare_soferi
				PRINT(@msg_eroare)
				RAISERROR(@msg_eroare,14,1)
			END


			DECLARE @id_zona INT
			SET @id_zona = dbo.get_next_id_zona();
			--SELECT NEXT ID FOR ZONA
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT id_zona from', 'Zone', GETDATE())
			--INSERT INTO ZONE
			INSERT INTO Zone(id_zona, nume, oras) VALUES (@id_zona, @nume_zona, @nume_oras)
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'Zone', GETDATE())

			DECLARE @id_sofer INT
			SET @id_sofer = dbo.get_next_id_sofer();
			--SELECT NEXT ID FOR SOFER
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT id_sofer from', 'Soferi', GETDATE())
			--INSERT INTO SOFERI
			INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (@id_sofer, @nume_sofer, @prenume_sofer, @telefon_sofer)
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'Soferi', GETDATE())

			--INSERT in ZONESOFERI
			INSERT INTO ZoneSoferi(id_zona, id_sofer) VALUES (@id_zona, @id_sofer)
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'ZoneSoferi', GETDATE())
			
			COMMIT TRAN
			SELECT 'Transaction committed'
		END TRY
		
		BEGIN CATCH
			ROLLBACK TRAN
			SELECT 'Transaction rollbacked'
		END CATCH
END
GO

DELETE FROM Rating
DELETE FROM ComenziActive
DELETE FROM Restaurante
DELETE FROM Masini
DELETE FROM Soferi
DELETE FROM Zone
DELETE FROM ZoneSoferi
DELETE FROM LogTable
INSERT INTO Zone(id_zona, nume, oras) VALUES (1, 'Test1', 'Test1')
INSERT INTO Zone(id_zona, nume, oras) VALUES (2, 'Test2', 'Test2')
INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (1, 'Test1', 'Test1', '0771272504')
INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (2, 'Test2', 'Test2', '0771272504')

--testare pentru prima problema in care se face rollback la tot
SELECT * FROM Zone
SELECT * FROM Soferi
SELECT * FROM ZoneSoferi
SELECT @@TRANCOUNT as TranCount
--COMMIT TRAN REALIZAT CU SUCCES
EXEC insert_with_total_rollback 'Zorilor', 'Cluj', 'Ionut', 'Bratu', '0771272504'
--TRAN UNDE SE FACE ROLLBACK
EXEC insert_with_total_rollback '123', 'Turda', 'Ionut', '92dd1ii121-', '023919391391392193193912'
SELECT * FROM Zone
SELECT * FROM Soferi
SELECT * FROM ZoneSoferi
SELECT @@TRANCOUNT as TranCount

SELECT * FROM LogTable

--Creaþi o procedurã stocatã ce insereazã date pentru entitãþi ce se aflã într-o relaþie m-n. 
--Dacã o operaþie de inserare eºueazã va trebui sã se pãstreze cât mai mult posibil din ceea ce s-a modificat pânã în acel moment.

GO
CREATE OR ALTER PROCEDURE insert_with_partial_rollback @nume_zona VARCHAR(30), @nume_oras VARCHAR(30), @nume_sofer VARCHAR(30), @prenume_sofer VARCHAR(30), @telefon_sofer VARCHAR(30)
AS
BEGIN
	DECLARE @id_zona INT
	SET @id_zona = -1;
	DECLARE @id_sofer INT
	SET @id_sofer = -1;
	BEGIN TRAN
		--INSERT in Zone
		BEGIN TRY
			DECLARE @msg_eroare_zone VARCHAR(1500)
			SET @msg_eroare_zone = dbo.VALIDARE_ZONE(@nume_zona, @nume_oras)
			IF (LEN(@msg_eroare_zone) > 0)
			BEGIN 
				RAISERROR(@msg_eroare_zone,14,1)
			END			
			SET @id_zona = dbo.get_next_id_zona();
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT id_zona from', 'Zone', GETDATE())
			INSERT INTO Zone(id_zona, nume, oras) VALUES (@id_zona, @nume_zona, @nume_oras)
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'Zone', GETDATE())

			COMMIT TRAN
			SELECT 'Transaction committed for Zone'
		END TRY
		
		BEGIN CATCH
			ROLLBACK TRAN
			SELECT 'Transaction rollbacked for Zone'
		END CATCH
	--INSERT in Soferi
	BEGIN TRAN
		BEGIN TRY
			DECLARE @msg_eroare_soferi VARCHAR(1500)
			SET @msg_eroare_soferi = dbo.VALIDARE_SOFER(@nume_sofer, @prenume_sofer, @telefon_sofer)
			IF (LEN(@msg_eroare_soferi) > 0)
			BEGIN 
				RAISERROR(@msg_eroare_soferi,14,1)
			END			
			SET @id_sofer = dbo.get_next_id_sofer();
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT id_sofer from', 'Soferi', GETDATE())
			INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (@id_sofer, @nume_sofer, @prenume_sofer, @telefon_sofer)
			INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'Soferi', GETDATE())

			COMMIT TRAN
			SELECT 'Transaction committed for Soferi'
		END TRY
		
		BEGIN CATCH
			ROLLBACK TRAN
			SELECT 'Transaction rollbacked for Soferi'
		END CATCH
	--INSERT in ZoneSoferi
		BEGIN TRAN
			BEGIN TRY
				IF (@id_sofer = -1 or @id_zona = -1)
				BEGIN 
					RAISERROR('Nu se poate face inserare in tabela ZoneSoferi',14,1);
				END
				INSERT INTO ZoneSoferi(id_zona, id_sofer) VALUES (@id_zona, @id_sofer)
				INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('INSERT INTO', 'ZoneSoferi', GETDATE())
			
				COMMIT TRAN
				SELECT 'Transaction committed for ZoneSoferi'
			END TRY
		
			BEGIN CATCH
				ROLLBACK TRAN
				SELECT 'Transaction rollbacked for ZoneSoferi'
			END CATCH
END
GO

DELETE FROM Rating
DELETE FROM ComenziActive
DELETE FROM Restaurante
DELETE FROM Masini
DELETE FROM Soferi
DELETE FROM Zone
DELETE FROM ZoneSoferi
DELETE FROM LogTable
INSERT INTO Zone(id_zona, nume, oras) VALUES (1, 'Test1', 'Test1')
INSERT INTO Zone(id_zona, nume, oras) VALUES (2, 'Test2', 'Test2')
INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (1, 'Test1', 'Test1', '0771272504')
INSERT INTO Soferi(id_sofer, nume, prenume, telefon) VALUES (2, 'Test2', 'Test2', '0771272504')

--testare pentru a doua problema in care se face rollback partial
SELECT * FROM Zone
SELECT * FROM Soferi
SELECT * FROM ZoneSoferi
SELECT @@TRANCOUNT as TranCount

--se insereaza corect in toate tabelele
EXEC insert_with_partial_rollback 'Ferentari', 'Bucuresti', 'Pop', 'Daniel', '0712355133'
--se insereaza doar in tabela Zone
EXEC insert_with_partial_rollback 'Giulesti', 'Bucuresti', '102301d01d0121', 'dk1k1kd12d0120k', '0771272504'
--se insereaza doar in tabela Soferi
EXEC insert_with_partial_rollback 'f1121f12f21f112', 'f1f1f21f12f1', 'Bratu', 'Ionut', '0715355133'
--nu se insereaza nimic in nicio tabela
EXEC insert_with_partial_rollback '3103102', '31020d1adada', '', '', '03129831283813818318318'

SELECT * FROM Zone
SELECT * FROM Soferi
SELECT * FROM ZoneSoferi
SELECT @@TRANCOUNT as TranCount
SELECT * FROM LogTable