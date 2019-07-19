CREATE TABLE [dbo].[UserTrack]
(
	[UserId] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [TaskId] INT NOT NULL REFERENCES Task(TaskId) ON DELETE CASCADE,
    [TaskTrackId] INT NOT NULL REFERENCES TaskTrack(TaskTrackId) ON DELETE CASCADE, 
    [TaskName] NCHAR(50) NOT NULL, 
    [TrackNote] NCHAR(250) NULL, 
    [TrackDate] DATETIME NOT NULL
)
