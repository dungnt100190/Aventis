CREATE TABLE [dbo].[XPermissionGroup](
	[PermissionGroupID] [int] IDENTITY(1,1) NOT NULL,
	[PermissionGroupName] [varchar](100) NOT NULL,
	[Description] [varchar](max) NULL,
	[XPermissionGroupTS] [timestamp] NOT NULL,
	[Kompetenzstufe] [int] NULL,
 CONSTRAINT [PK_XPermissionGroup] PRIMARY KEY CLUSTERED 
(
	[PermissionGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XPermissionGroup Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XPermissionGroup', @level2type=N'COLUMN',@level2name=N'PermissionGroupID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert die Reihenfolge in der die Empfänger der Bewilligungsanfragen ermittelt werden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XPermissionGroup', @level2type=N'COLUMN',@level2name=N'Kompetenzstufe'
GO