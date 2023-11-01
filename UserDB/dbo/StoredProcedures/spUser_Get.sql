CREATE PROCEDURE [dbo].[spUser_Get]
	@Id int
AS
BEGIN
	SELECT Id, FirstName, LastName
	FROM [User]
	WHERE Id = @Id;
END