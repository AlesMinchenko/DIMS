CREATE PROCEDURE [dbo].[DeleteTask]
	@taskid int
AS
	Delete from Task
	where TaskId = @taskid
