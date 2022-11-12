ALTER TABLE dbo.Users ADD
	UsesFacebookAuth bit not null default 0,
	UsesGoogleAuth bit not null default 0,
	UsesMicrosoftAuth bit not null default 0
GO