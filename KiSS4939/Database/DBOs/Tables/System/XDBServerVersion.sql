CREATE TABLE [dbo].[XDBServerVersion](
	[XDBServerVersionID] [int] IDENTITY(1,1) NOT NULL,
	[ServerVersion] [varchar](255) NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[XDBServerVersionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XDBServerVersion] PRIMARY KEY CLUSTERED 
(
	[XDBServerVersionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBServerVersion', @level2type=N'COLUMN',@level2name=N'XDBServerVersionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Aktuelle DB-Server-Version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBServerVersion', @level2type=N'COLUMN',@level2name=N'ServerVersion'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBServerVersion', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBServerVersion', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XDBServerVersion', @level2type=N'COLUMN',@level2name=N'XDBServerVersionTS'
GO

ALTER TABLE [dbo].[XDBServerVersion] ADD  CONSTRAINT [DF_XDBServerVersion_ServerVersion]  DEFAULT (@@version) FOR [ServerVersion]
GO

ALTER TABLE [dbo].[XDBServerVersion] ADD  CONSTRAINT [DF_XDBServerVersion_Created]  DEFAULT (getdate()) FOR [Created]
GO