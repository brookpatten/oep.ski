
ALTER TABLE dbo.Users ADD
	ProfileImageUrl varchar(1024) null
GO
CREATE TABLE dbo.FileUploads
	(
	Id int NOT NULL IDENTITY (1, 1),
	PatrolId int NULL,
	UserId int NULL,
	Name varchar(1023),
	FileSize int null,
	)  ON [PRIMARY]
GO