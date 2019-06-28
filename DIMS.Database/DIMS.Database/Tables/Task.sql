CREATE TABLE [dbo].[Task]
(
	[TaskId] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [Description] NCHAR(10) NULL, 
    [StartDate] DATETIME NOT NULL, 
    [DeadlineDate] DATETIME NOT NULL
)
