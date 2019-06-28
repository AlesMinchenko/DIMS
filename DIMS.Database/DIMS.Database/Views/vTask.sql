CREATE VIEW [dbo].[vTask]
		AS SELECT ISNULL(up.TaskId, -999) AS TaskId, --for Entity Framework primary key
			  up.DeadlineDate,
			  up.Description,
			  up.Name,
			  up.StartDate
			  FROM Task up
