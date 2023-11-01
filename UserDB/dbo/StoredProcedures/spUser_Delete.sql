CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int
AS
BEGIN
	DELETE
	FROM [User]
	WHERE Id = @Id;
END