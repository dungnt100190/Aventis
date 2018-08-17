CREATE TABLE [dbo].[XUserGroup](
	[UserGroupID] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupName] [varchar](100) NOT NULL,
	[UserGroupNameTID] [int] NULL,
	[OnlyAdminVisible] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
	[DescriptionTID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XUserGroupTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XUserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [SYSTEM]
) ON [SYSTEM]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Benutzergruppen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Benutzergruppe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'UserGroupName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Übersetzung für den Gruppenname (Wert in XLangText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'UserGroupNameTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Benutzergruppe nur von Administratoren eingesehen und bearbeitet werden kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'OnlyAdminVisible'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Optionale Beschreibung der Benutzergruppe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Übersetzung für die Beschreibung (Wert in XLangText)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'DescriptionTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup', @level2type=N'COLUMN',@level2name=N'XUserGroupTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Benutzergruppen für die Zuweisung der Rechte zu Benutzern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XUserGroup'
GO

ALTER TABLE [dbo].[XUserGroup] ADD  CONSTRAINT [DF_XUserGroup_OnlyAdminVisible]  DEFAULT ((0)) FOR [OnlyAdminVisible]
GO

ALTER TABLE [dbo].[XUserGroup] ADD  CONSTRAINT [DF_XUserGroup_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XUserGroup] ADD  CONSTRAINT [DF_XUserGroup_Modified]  DEFAULT (getdate()) FOR [Modified]
GO