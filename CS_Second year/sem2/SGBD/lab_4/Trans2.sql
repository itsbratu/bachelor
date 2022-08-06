go
use CarSharing
go

--DIRTY READS

--DIRTY READS INITIAL
GO
CREATE OR ALTER PROCEDURE trans2_dirty_reads_initial
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	BEGIN TRAN
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN
	SELECT * FROM LogTable
END
GO

EXEC trans2_dirty_reads_initial

--DIRTY READS SOLUTION
GO
CREATE OR ALTER PROCEDURE trans2_dirty_reads_solution
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN	
	DELETE FROM LogTable
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN
	SELECT * FROM LogTable
END
GO

EXEC trans2_dirty_reads_solution

--NON-REPEATABLE READS 

--NON-REPEATABLE READS INITIAL
GO
CREATE OR ALTER PROCEDURE trans2_non_repetable_reads_initial
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	BEGIN TRAN
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN
	SELECT * FROM LogTable
END
GO

EXEC trans2_non_repetable_reads_initial

--NON-REPEATABLE READS SOLUTION
GO
CREATE OR ALTER PROCEDURE trans2_non_repetable_reads_solution
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN
	SELECT * FROM LogTable
END
GO

EXEC trans2_non_repetable_reads_solution

--PHANTOM_READS

--PHANTOM_READS INITIAL
GO
CREATE OR ALTER PROCEDURE trans2_phantom_reads_initial
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	BEGIN TRAN
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN	SELECT * FROM LogTable
END
GO

EXEC trans2_phantom_reads_initial

--PHANTOM_READS SOLUTION
GO
CREATE OR ALTER PROCEDURE trans2_phantom_reads_solution
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	BEGIN TRAN
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	WAITFOR DELAY '00:00:10'
	SELECT * FROM Zone
	INSERT INTO LogTable(TypeOperation, TableOperation, ExecutionDate) VALUES('SELECT * FROM Zone', 'Zone', GETDATE())
	COMMIT TRAN	SELECT * FROM LogTable
END
GO

EXEC trans2_phantom_reads_solution

--DEADLOCK

--DEADLOCK INITIAL
GO
CREATE OR ALTER PROCEDURE trans2_deadlock_initial
AS
BEGIN
	BEGIN TRAN
	UPDATE Soferi set nume='Ionut' where id_sofer=1
	WAITFOR DELAY '00:00:07'
	UPDATE Zone set nume='Manastur' where id_zona=1
	COMMIT TRAN
END
GO

EXEC trans2_deadlock_initial

--DEADLOCK SOLUTION
GO
CREATE OR ALTER PROCEDURE trans2_deadlock_solution
AS
BEGIN
	BEGIN TRAN
	UPDATE Zone set nume='Manastur' where id_zona=1
	WAITFOR DELAY '00:00:07'
	UPDATE Soferi set nume='Ionut' where id_sofer=1
	COMMIT TRAN
END
GO

EXEC trans2_deadlock_solution

SELECT * FROM Zone
SELECT * FROM Soferi