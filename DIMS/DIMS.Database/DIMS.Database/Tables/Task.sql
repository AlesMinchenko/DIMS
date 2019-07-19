CREATE TABLE [dbo].[Task]
(
	[TaskId] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NOT NULL, 
    [Description] NCHAR(250) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [DeadlineDate] DATETIME NOT NULL
)
