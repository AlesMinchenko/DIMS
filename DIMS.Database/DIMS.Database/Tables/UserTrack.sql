CREATE TABLE [dbo].[UserTrack]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [TaskId] INT NOT NULL REFERENCES Task(TaskId) ON DELETE CASCADE,
    [TaskTrackId] INT NOT NULL REFERENCES TaskTrack(TaskTrackId) ON DELETE CASCADE, 
    [TaskName] NCHAR(10) NOT NULL, 
    [TrackNote] NCHAR(20) NULL, 
    [TrackDate] DATETIME NOT NULL
)
