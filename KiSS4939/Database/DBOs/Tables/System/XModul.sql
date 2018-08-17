CREATE TABLE [dbo].[XModul](
	[ModulID] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[ShortName] [varchar](10) NULL,
	[SortKey] [int] NULL,
	[NameSpace] [varchar](255) NULL,
	[DB_Prefix] [varchar](10) NULL,
	[ModulTree] [bit] NOT NULL,
	[Description] [varchar](max) NULL,
	[System] [bit] NOT NULL,
	[XModulTS] [timestamp] NOT NULL,
	[Licensed] [bit] NOT NULL,
 CONSTRAINT [PK_XModul] PRIMARY KEY CLUSTERED 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XModul Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XModul', @level2type=N'COLUMN',@level2name=N'ModulID'
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


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob ein Modul lizenziert wurde oder nicht (1=Kunde hat Lizenz, 0=Kunde hat keine Lizenz)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XModul', @level2type=N'COLUMN',@level2name=N'Licensed'
GO

ALTER TABLE [dbo].[XModul] ADD  CONSTRAINT [DF_XModul_ModulTree]  DEFAULT ((1)) FOR [ModulTree]
GO

ALTER TABLE [dbo].[XModul] ADD  CONSTRAINT [DF_XModul_System]  DEFAULT ((0)) FOR [System]
GO

ALTER TABLE [dbo].[XModul] ADD  CONSTRAINT [DF_XModul_Licensed]  DEFAULT ((0)) FOR [Licensed]
GO
