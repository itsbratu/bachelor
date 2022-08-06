use CarSharing
go

CREATE OR ALTER FUNCTION VALIDARE_CRUD_SOFERI(@id_sofer VARCHAR(1000) , @nume VARCHAR(1000) , @prenume VARCHAR(1000) , @telefon VARCHAR(1000))
RETURNS VARCHAR(1500) AS
BEGIN
		DECLARE @msg_eroare VARCHAR(1500);
		SET @msg_eroare = '';
		IF (@id_sofer LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Id sofer trebuie sa fie un numar!,'
		END
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

CREATE OR ALTER PROCEDURE CRUD_SOFERI
	@id_sofer VARCHAR(1000),
	@nume VARCHAR(1000),
	@prenume VARCHAR(1000),
	@telefon VARCHAR(1000)
AS
BEGIN
	SET NOCOUNT ON;
	--verificare parametri
	DECLARE @msg_eroare VARCHAR(1500);	
	SET @msg_eroare = '';

	SET @msg_eroare = dbo.VALIDARE_CRUD_SOFERI(@id_sofer , @nume , @prenume , @telefon);

	IF (LEN(@msg_eroare) > 0)
	BEGIN
		PRINT @msg_eroare
		RETURN
	END

	SET @id_sofer = CAST(@id_sofer AS int)

	IF EXISTS (SELECT 1 FROM Soferi WHERE Soferi.id_sofer = @id_sofer)
	BEGIN
		SET @msg_eroare = @msg_eroare + 'Exista deja un sofer cu acest ID!,'
	END

	SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
	IF LEN(@msg_eroare) > 0
	BEGIN
		PRINT(@msg_eroare)
		RETURN
	END
	ELSE
	BEGIN
		--CREATE = INSERT
		INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (@id_sofer , @nume , @prenume , @telefon)

		--READ = SELECT
		SELECT * FROM Soferi WHERE Soferi.id_sofer = id_sofer

		--UPDATE
		UPDATE Soferi SET Soferi.prenume = 'Ionut' , Soferi.telefon = '0771272504' WHERE Soferi.id_sofer = @id_sofer
		--ne asiguram ca s-a facut cu succes update-ul
		SELECT * FROM Soferi WHERE Soferi.id_sofer = id_sofer

		--DELETE
		DELETE FROM Soferi WHERE Soferi.id_sofer = @id_sofer
		--ne asiguram ca s-a facut cu succes delete-ul
		SELECT * FROM Soferi WHERE Soferi.id_sofer = id_sofer
		PRINT('Operatiile CRUD au fost executate cu succes pe tabela Soferi!');
	END
END

DELETE FROM Soferi
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES(12 , 'Bratu' , 'Ionut' , '0231233311')
EXEC CRUD_SOFERI @id_sofer = '12' , @nume = 'Bratu' , @prenume = 'Andrei' , @telefon = '0771272504'

CREATE OR ALTER FUNCTION VALIDARE_CRUD_COMENZI(@id_comanda VARCHAR(1000) , @id_user VARCHAR(1000) , @locatie_initiala NVARCHAR(1000) , @locatie_finala NVARCHAR(1000) , @timp_initial VARCHAR(1000) , @timp_final VARCHAR(1000))
RETURNS VARCHAR(1500) AS
BEGIN
		DECLARE @msg_eroare VARCHAR(1500);
		SET @msg_eroare = '';
		IF (@id_comanda LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Id comanda trebuie sa fie un numar!,'
		END
		IF (@id_user LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Id user trebuie sa fie un numar!,'
		END
		IF (@locatie_initiala LIKE '%[!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Locatia initiala trebuie sa contina doar litere si cifre!,'
		END
		IF (@locatie_finala LIKE '%[!@#$%^&*()_-+=]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Locatia finala trebuie sa contina doar litere si cifre!,'
		END
		IF (@timp_initial LIKE '%[a-zA-Z!@#$%^&*()_-+=]%')
		BEGIN 
			SET @msg_eroare = @msg_eroare + 'Timpul initial poate sa contina doar cifre si caracterul:!,'
		END
		IF (@timp_final LIKE '%[a-zA-Z!@#$%^&*()_-+=]%')
		BEGIN 
			SET @msg_eroare = @msg_eroare + 'Timpul final poate sa contina doar cifre si caracterul:!,'
		END
		IF LEN(@locatie_initiala) > 40 OR LEN(@locatie_initiala) < 1 SET @msg_eroare = @msg_eroare + 'Dimensiunea locatiei initiale trebuie sa fie intre 1 si 40 de caractere!,'
		IF LEN(@locatie_finala) > 40 OR LEN(@locatie_finala) < 1 SET @msg_eroare = @msg_eroare  + 'Dimensiunea locatiei finale trebuie sa fie intre 1 si 40 de caractere!,'
		IF LEN(@timp_initial) < 3 OR LEN(@timp_initial) > 8 SET @msg_eroare = @msg_eroare + 'Dimensiunea timpului initial trebuie sa fie intre 3 si 8 caractere!,'
		IF LEN(@timp_final) < 3 OR LEN(@timp_final) > 8 SET @msg_eroare = @msg_eroare + 'Dimensiunea timpului final trebuie sa fie intre 3 si 8 caractere!,'


		SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
		RETURN @msg_eroare;
END

CREATE OR ALTER PROCEDURE CRUD_COMENZI
	@id_comanda VARCHAR(1000),
	@id_user VARCHAR(1000),
	@locatie_initiala NVARCHAR(1000),
	@locatie_finala NVARCHAR(1000),
	@timp_initial VARCHAR(1000),
	@timp_final VARCHAR(1000)
AS
BEGIN
	SET NOCOUNT ON;
	--verificare parametri
	DECLARE @msg_eroare VARCHAR(1500);	
	SET @msg_eroare = '';

	SET @msg_eroare = dbo.VALIDARE_CRUD_COMENZI(@id_comanda , @id_user , @locatie_initiala , @locatie_finala , @timp_initial , @timp_final);

	IF (LEN(@msg_eroare) > 0)
	BEGIN
		PRINT @msg_eroare
		RETURN
	END

	SET @id_comanda = CAST(@id_comanda AS int)
	SET @id_user = CAST(@id_user AS int)
	SET @timp_initial = CAST(@timp_initial AS time(7))
	SET @timp_final = CAST(@timp_final AS time(7))

	IF NOT EXISTS (SELECT 1 FROM Useri WHERE Useri.id_user = @id_user)
	BEGIN
		SET @msg_eroare = @msg_eroare + 'Nu exista un user cu acest ID!,'
	END
	IF EXISTS (SELECT 1 FROM Comenzi WHERE Comenzi.id_comanda = @id_comanda)
	BEGIN
		SET @msg_eroare = @msg_eroare + 'Exista deja o comanda cu acest ID!,'
	END

	SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
	IF LEN(@msg_eroare) > 0
	BEGIN
		PRINT(@msg_eroare)
		RETURN
	END
	ELSE
	BEGIN
		--CREATE = INSERT
		INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES (@id_comanda , @id_user , @locatie_initiala , @locatie_finala , @timp_initial , @timp_final)

		--READ = SELECT
		SELECT * FROM Comenzi WHERE Comenzi.id_comanda = @id_comanda

		--UPDATE
		UPDATE Comenzi SET Comenzi.locatie_initiala = 'Strada Unirii nr.8' , Comenzi.locatie_finala = 'Strada Gheorghe Dima nr.6' WHERE Comenzi.id_comanda = @id_comanda
		--ne asiguram ca s-a facut cu succes update-ul
		SELECT * FROM Comenzi WHERE Comenzi.id_comanda = @id_comanda

		--DELETE
		DELETE FROM Comenzi WHERE Comenzi.id_comanda = @id_comanda
		--ne asiguram ca s-a facut cu succes delete-ul
		SELECT * FROM Comenzi WHERE Comenzi.id_comanda = @id_comanda
		PRINT('Operatiile CRUD au fost executate cu succes pe tabela Comenzi!');
	END
END

DELETE FROM Comenzi
EXEC CRUD_COMENZI @id_comanda = '12' , @id_user = 1 , @locatie_initiala = 'Strada Petresti nr.101' , @locatie_finala = 'Strada macului nr.18' , @timp_initial = '12:00' , @timp_final = '15:00' 

CREATE OR ALTER FUNCTION VALIDARE_CRUD_COMENZI_ACTIVE(@id_livrator VARCHAR(1000) , @id_livrare VARCHAR(1000) , @tip_mancare VARCHAR(1000))
RETURNS VARCHAR(1500) AS
BEGIN
		DECLARE @msg_eroare VARCHAR(1500);
		SET @msg_eroare = '';
		IF (@id_livrator LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Id livrator trebuie sa fie un numar!,'
		END
		IF (@id_livrare LIKE '%[a-zA-Z!@#$%^&*()_-+={}]%')
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Id livrare trebuie sa fie un numar!,'
		END
		IF LEN(@tip_mancare) < 1 OR LEN(@tip_mancare) > 1
		BEGIN
			SET @msg_eroare = @msg_eroare + 'Caracterul introdus pentru tipul de mancare trebuie sa fie 0 sau 1!,'
		END
		ELSE
		BEGIN
			IF (NOT @tip_mancare = '0') AND (NOT @tip_mancare = '1')
			BEGIN
				SET @msg_eroare = @msg_eroare + 'Caracterul introdus pentru tipul de mancare trebuie sa fie 0 sau 1!,'
			END
		END

		SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
		RETURN @msg_eroare;
END

CREATE OR ALTER PROCEDURE CRUD_COMENZI_ACTIVE
	@id_livrator VARCHAR(1000),
	@id_livrare VARCHAR(1000),
	@tip_mancare VARCHAR(1000)
AS
BEGIN
	SET NOCOUNT ON;
	--verificare parametri
	DECLARE @msg_eroare VARCHAR(1500);	
	SET @msg_eroare = '';

	SET @msg_eroare = dbo.VALIDARE_CRUD_COMENZI_ACTIVE(@id_livrator , @id_livrare , @tip_mancare);

	IF (LEN(@msg_eroare) > 0)
	BEGIN
		PRINT @msg_eroare
		RETURN
	END

	SET @id_livrator = CAST(@id_livrator AS int)
	SET @id_livrare = CAST(@id_livrare AS int)
	SET @tip_mancare = CAST(@tip_mancare AS bit)

	IF NOT EXISTS (SELECT 1 FROM Soferi WHERE Soferi.id_sofer = @id_livrator)
	BEGIN
		SET @msg_eroare = @msg_eroare + 'Nu exista livratorul cu id-ul respectiv!,'
	END

	IF NOT EXISTS (SELECT 1 FROM Comenzi WHERE Comenzi.id_comanda = @id_livrare)
	BEGIN
		SET @msg_eroare = @msg_eroare + 'Nu exista comanda cu id-ul respectiv!,'
	END


	SET @msg_eroare = REPLACE(@msg_eroare , ',' , CHAR(10));
	IF LEN(@msg_eroare) > 0
	BEGIN
		PRINT(@msg_eroare)
		RETURN
	END
	ELSE
	BEGIN
		--CREATE = INSERT
		INSERT INTO ComenziActive(id_livrator , id_livrare , tip_mancare) VALUES (@id_livrator , @id_livrare , @tip_mancare)

		--READ = SELECT
		SELECT * FROM ComenziActive WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)

		--UPDATE
		IF @tip_mancare = '0'
		BEGIN
			UPDATE ComenziActive SET ComenziActive.tip_mancare = '1' WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)
		END
		ELSE
		BEGIN
			UPDATE ComenziActive SET ComenziActive.tip_mancare = '0' WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)
		END

		--ne asiguram ca s-a facut cu succes update-ul
		SELECT * FROM ComenziActive WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)

		--DELETE
		DELETE FROM ComenziActive WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)
		--ne asiguram ca s-a facut cu succes delete-ul
		SELECT * FROM ComenziActive WHERE (ComenziActive.id_livrator = @id_livrator AND ComenziActive.id_livrare = @id_livrare)
		PRINT('Operatiile CRUD au fost executate cu succes pe tabela ComenziActive!');
	END
END

INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (1 , 'Bratu' , 'Ionut' , '0771272504')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES (1 , 1 , 'Gheorghe Dima' , 'Piata Unirii' , '12:30:00' , '13:00:00')
EXEC CRUD_COMENZI_ACTIVE @id_livrator = '1' , @id_livrare = '1' , @tip_mancare = '1'

DELETE FROM Soferi
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (1 , 'Bratu' , 'Ionut' , '0771272504')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (2 , 'Bratu' , 'Andrei' , '0712200099')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (3 , 'Oltean' , 'Paul' , '0712230129')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (4 , 'Baciu' , 'Ioan' , '0712228800')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (5 , 'Stancu' , 'Tudor' , '0712199120')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (6 , 'Bratu' , 'Andrei' , '0721787111')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (7 , 'Baciu' , 'Irinel' , '0723123111')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (8 , 'Moldovan' , 'Cornel' , '0712800099')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (9 , 'Bratu' , 'Iacob' , '0741299001')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (10 , 'Poclid' , 'Malina' , '0741594331')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (11 , 'Vana' , 'Paul' , '0733311109')
INSERT INTO Soferi(id_sofer , nume , prenume , telefon) VALUES (12 , 'Baltac' , 'Ionut' , '0766612345')
SELECT * FROM Soferi

CREATE OR ALTER VIEW soferiNumeView
AS
	SELECT Soferi.nume FROM Soferi
	WHERE ((Soferi.nume LIKE 'B%') AND (Soferi.prenume LIKE 'I%'))
GO

SELECT sys.dm

SELECT * FROM soferiNumeView
ORDER BY nume

DELETE FROM Comenzi
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(1 , 1 , 'Gheorghe Dima' , 'Strada Unirii' , '12:30:00' , '13:00:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(2 , 1 , 'Strada Constructorilor' , 'Strada Unirii' , '12:00:00' , '12:30:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(3 , 1 , 'Strada Macilor' , 'Gheorghe Dima' , '16:00:00' , '16:20:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(4 , 1 , 'Strada Potaissa' , 'Strada Unirii' , '12:15:00' , '12:30:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(5 , 1 , 'Strada Constructorilor' , 'Gheorghe Dima' , '17:45:00' , '18:00:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(6 , 1 , 'Strada Castanelor' , 'Strada Unirii' , '12:40:00' , '12:55:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(7 , 1 , 'Strada Unirii' , 'Strada Constructorilor' , '12:30:00' , '12:45:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(8 , 1 , 'Dorobantilor' , 'Strada Unirii' , '13:15:00' , '14:30:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(9 , 1 , 'Dorobantilor' , 'Avram Iancu' , '12:15:00' , '12:20:00')
INSERT INTO Comenzi(id_comanda , id_user , locatie_initiala , locatie_finala , timp_initial , timp_final) VALUES(10 , 1 , 'Avram Iancu' , 'Gheorghe Dima' , '10:00:00' , '10:20:00')
SELECT * FROM Comenzi

CREATE OR ALTER VIEW comenziTimpView
AS
	SELECT * FROM Comenzi
	WHERE ((Comenzi.timp_initial > '11:59:00') AND (Comenzi.timp_final < '13:00:00'))
GO

SELECT * FROM comenziTimpView
ORDER BY timp_initial