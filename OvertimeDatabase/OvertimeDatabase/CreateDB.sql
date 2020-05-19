DECLARE @databaseName sysname;  
SET @databaseName = 'Overtime';  

if db_id(@databaseName) is not null
	BEGIN
	   PRINT 'Database exists, nothing to do';
	END
ELSE
	BEGIN
		CREATE DATABASE Overtime;
	END
GO

USE Overtime;
GO  


IF OBJECT_ID('dbo.Student', 'U') IS NOT NULL
DROP TABLE dbo.Student;
GO


CREATE TABLE dbo.Student
   (
	Prename nvarchar(20),
	Surname nvarchar(20),
	Room nvarchar(8),
	TimeStartM int,
	TimeStartH int,
	TimeEndM int,
	TimeEndH int
   ) ;
