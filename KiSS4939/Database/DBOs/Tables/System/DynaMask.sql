CREATE TABLE [dbo].[DynaMask](
	[MaskName] [varchar](100) NOT NULL,
	[ParentMaskName] [varchar](100) NULL,
	[ParentPosition] [int] NULL,
	[ModulID] [int] NOT NULL,
	[FaModulCode] [int] NULL,
	[FaPhaseCode] [int] NULL,
	[VmProzessCode] [int] NULL,
	[DisplayText] [varchar](100) NOT NULL,
	[IconID] [int] NULL,
	[TabNames] [varchar](500) NULL,
	[GridHeight] [int] NULL,
	[System] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[AppCode] [varchar](200) NULL,
	[DynaMaskTS] [timestamp] NOT NULL,
	[KaProzessCode] [int] NULL,
	[DisplayTextTID] [int] NULL,
 CONSTRAINT [PK_DynaMask] PRIMARY KEY CLUSTERED 
(
	[MaskName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_DynaMask_FaPhaseCode]    Script Date: 11/23/2011 14:38:11 ******/
CREATE NONCLUSTERED INDEX [IX_DynaMask_FaPhaseCode] ON [dbo].[DynaMask] 
(
	[FaPhaseCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_DynaMask_ParentMaskName]    Script Date: 11/23/2011 14:38:11 ******/
CREATE NONCLUSTERED INDEX [IX_DynaMask_ParentMaskName] ON [dbo].[DynaMask] 
(
	[ParentMaskName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_DynaMask_ParentPosition]    Script Date: 11/23/2011 14:38:11 ******/
CREATE NONCLUSTERED INDEX [IX_DynaMask_ParentPosition] ON [dbo].[DynaMask] 
(
	[ParentPosition] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für DynaMask Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaMask', @level2type=N'COLUMN',@level2name=N'MaskName'
GO

ALTER TABLE [dbo].[DynaMask]  WITH CHECK ADD  CONSTRAINT [FK_DynaMask_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[DynaMask] CHECK CONSTRAINT [FK_DynaMask_XModul]
GO

ALTER TABLE [dbo].[DynaMask] ADD  CONSTRAINT [DF_DynaMask_System]  DEFAULT (0) FOR [System]
GO

ALTER TABLE [dbo].[DynaMask] ADD  CONSTRAINT [DF_DynaMask_Active]  DEFAULT (0) FOR [Active]
GO


