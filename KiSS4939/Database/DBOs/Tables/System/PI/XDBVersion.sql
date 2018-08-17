CREATE TABLE [dbo].[XDBVersion] (
	[XDBVersionID] [int] IDENTITY (1, 1) NOT NULL ,
	[MajorVersion] [int] NOT NULL ,
	[MinorVersion] [int] NOT NULL ,
	[Build] [int] NOT NULL ,
	[Revision] [int] NOT NULL ,
	[VersionDate] [datetime] NOT NULL ,
	[SQLServerVersionInfo] [varchar] (500) NOT NULL ,
	[ChangesSinceLastVersion] [varchar] (MAX) NULL ,
	[BackwardCompatibleDownToClientVersion] [varchar] (20) NOT NULL ,
	[Description] [varchar] (500) NULL ,
	[Creator] [varchar] (50) NOT NULL ,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XDBVersion_Created] DEFAULT (GetDate()),
	[Modifier] [varchar] (50) NOT NULL ,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XDBVersion_Modified] DEFAULT (GetDate()),
	[XDBVersionTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XDBVersion] PRIMARY KEY  Clustered
	(
		[XDBVersionID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'Author', N'Reto Stahel (erstellt am 1.10.2009)', N'user', N'dbo', N'table', N'XDBVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'KiSS DB-Version History', N'user', N'dbo', N'table', N'XDBVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XDBVersion Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'XDBVersionID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'First Version number from the full version (e.g. "4.1.37.804"), so Major would be 4 in this example', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'MajorVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Second Version number from the full version (e.g. "4.1.37.804"), so Minor would be 1 in this example', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'MinorVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Third Version number from the full version (e.g. "4.1.37.804"), so Build would be 37 in this example', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Build'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Last Version number from the full version (e.g. "4.1.37.804"), so Revision would be 804 in this example', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Revision'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Date when the DBVersion-Entry was made. This is also the sort order to determine the current version!', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'VersionDate'
GO
EXEC sp_addextendedproperty N'MS_Description', N'SQL-Server Version information at the time when the DBVersion-Entry was made.', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'SQLServerVersionInfo'
GO
EXEC sp_addextendedproperty N'MS_Description', N'A list of all DB-Objects which where changed since the last DBVersion-Entry.', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'ChangesSinceLastVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'String representing the earliest compatible Client Version. E.g. if this is set to "4.1.37.800" it means that all Clients from 4.1.37.800 and later are compatible wit the DB-Schema and the DB-Objects.', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'BackwardCompatibleDownToClientVersion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Optional Description of the Version (e.g. if this Build is for a specific Customer only)', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz erstellt wurde', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Created'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Modifier'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz zuletzt geändert wurde', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'Modified'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'XDBVersion', N'column', N'XDBVersionTS'
GO
