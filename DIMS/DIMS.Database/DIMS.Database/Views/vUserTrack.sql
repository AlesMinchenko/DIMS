CREATE VIEW [dbo].[vUserTrack]
	AS SELECT ISNULL(up.UserId, -999) AS UserId, --for Entity Framework primary key
			  up.TaskId,
			  up.TaskName,
			  up.TaskTrackId,
			  up.TrackNote,
			  up.TrackDate
			  FROM [UserTrack] up join [Task] task on up.TaskId = task.TaskId
			  join [TaskTrack] tasktrack on up.TaskTrackId = tasktrack.TaskTrackId