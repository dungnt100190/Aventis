CREATE TABLE [dbo].[XDBVersion](
	[XDBVersionID] [int] IDENTITY(1,1) NOT NULL,
	[MajorVersion] [int] NOT NULL,
	[MinorVersion] [int] NOT NULL,
	[Build] [int] NOT NULL,
	[Revision] [int] NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[SQLServerVersionInfo] [varchar](500) NOT NULL,
	[ChangesSinceLastVersion] [varchar](max) NULL,
	[BackwardCompatibleDownToClientVersion] [varchar](20) NOT NULL,
	[Description] [varchar](500) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XDBVersion_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XDBVersion_Modified]  DEFAULT (getdate()),
	[XDBVersionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDBVersion] PRIMARY KEY CLUSTERED 
(
	[XDBVersionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XDBVersion Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'XDBVersionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'First Version number from the full version (e.g. "4.1.37.804"), so Major would be 4 in this example' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'MajorVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Second Version number from the full version (e.g. "4.1.37.804"), so Minor would be 1 in this example' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'MinorVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Third Version number from the full version (e.g. "4.1.37.804"), so Build would be 37 in this example' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Build'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last Version number from the full version (e.g. "4.1.37.804"), so Revision would be 804 in this example' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Revision'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Date when the DBVersion-Entry was made. This is also the sort order to determine the current version!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'VersionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SQL-Server Version information at the time when the DBVersion-Entry was made.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'SQLServerVersionInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A list of all DB-Objects which where changed since the last DBVersion-Entry.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'ChangesSinceLastVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'String representing the earliest compatible Client Version. E.g. if this is set to "4.1.37.800" it means that all Clients from 4.1.37.800 and later are compatible wit the DB-Schema and the DB-Objects.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'BackwardCompatibleDownToClientVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optional Description of the Version (e.g. if this Build is for a specific Customer only)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion', @level2type=N'COLUMN',@level2name=N'XDBVersionTS'
GO
EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Reto Stahel (erstellt am 1.10.2009)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KiSS DB-Version History' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBVersion'