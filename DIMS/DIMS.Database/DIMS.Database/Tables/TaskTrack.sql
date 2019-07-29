CREATE TABLE [dbo].[TaskTrack]
(
	[TaskTrackId] INT identity(1,1) NOT NULL PRIMARY KEY,
	[UserTaskId] int not null REFERENCES UserTask(UserTaskId) ON DELETE CASCADE,
	[TrackDate] datetime not null,
	[TrackNote] NCHAR (250) null
)
