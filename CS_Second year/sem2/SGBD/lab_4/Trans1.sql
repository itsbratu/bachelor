go
use CarSharing
go

--DIRTY READS
GO
CREATE OR ALTER PROCEDURE trans1_dirty_reads
AS
BEGIN
	BEGIN TRAN
	UPDATE Zone SET
	oras='Cluj-Napoca' WHERE id_zona = 1
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('UPDATE Zone SET oras', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:07'
	ROLLBACK TRAN
END
GO

EXEC trans1_dirty_reads
	
--NON-REPETABLE READS
GO
CREATE OR ALTER PROCEDURE trans1_non_repetable_reads
AS
BEGIN
	INSERT INTO Zone(id_zona, nume, oras) VALUES
	(100, 'Zorilor','Cluj-Napoca')
	BEGIN TRAN
	WAITFOR DELAY '00:00:07'
	UPDATE Zone SET nume='Manastur', oras='Cluj' WHERE
	id_zona = 100
	COMMIT TRAN
END
GO

DELETE FROM Zone Where id_zona = 100
EXEC trans1_non_repetable_reads

--PHANTOM READS
GO
CREATE OR ALTER PROCEDURE trans1_phantom_reads
AS
BEGIN
	BEGIN TRAN
	WAITFOR DELAY '00:00:07'
	INSERT INTO Zone(id_zona,nume, oras) VALUES (101, 'Ferentari','Bucuresti')
	COMMIT TRAN
END
GO

DELETE FROM Zone Where id_zona = 101
EXEC trans1_phantom_reads

--DEAD LOCK

--INITIAL
GO
CREATE OR ALTER PROCEDURE trans1_deadlock_initial
AS
BEGIN
	BEGIN TRAN
	UPDATE Zone set nume='Manastur' where id_zona = 1
	waitfor delay '00:00:07'
	Update Soferi set nume='Ionut' where id_sofer = 1
	commit tran
END
GO

EXEC trans1_deadlock_initial

--CREATE LOG

CREATE TABLE Log_Table 
(
Lid INT PRIMARY KEY IDENTITY,
TypeOperation VARCHAR(50),
TableOperation VARCHAR(50),
ExecutionDate DATETIME,
);

--GET LAST ID 
DECLARE @wantedId INT;
SET @wantedId = (
   SELECT MAX(column) FROM table
);

--INDEX

GO
CREATE OR ALTER PROCEDURE index_proc
AS
BEGIN
	CREATE INDEX tari_nume_tara ON Tari(nume_tara);
	SELECT nume_tara FROM Tari WHERE nume_tara LIKE 'A%' ORDER BY nume_tara;
	DROP INDEX tari_nume_tara ON Tari
END
GO

SET SHOWPLAN_ALL ON
GO

SET FMTONLY ON
GO

exec index_proc
GO

SET FMTONLY OFF
GO

SET SHOWPLAN_ALL OFF
GO