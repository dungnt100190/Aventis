CREATE TABLE [dbo].[DynaField](
	[DynaFieldID] [int] IDENTITY(1,1) NOT NULL,
	[MaskName] [varchar](100) NOT NULL,
	[FieldName] [varchar](100) NOT NULL,
	[FieldCode] [int] NOT NULL,
	[DisplayText] [varchar](200) NULL,
	[TabPosition] [int] NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Width] [int] NULL,
	[Height] [int] NULL,
	[Length] [int] NULL,
	[LOVName] [varchar](100) NULL,
	[SQL] [varchar](4000) NULL,
	[DefaultValue] [varchar](200) NULL,
	[Mandatory] [bit] NULL,
	[TabName] [varchar](50) NULL,
	[GridColTitle] [varchar](100) NULL,
	[GridColWidth] [int] NULL,
	[GridColPosition] [int] NULL,
	[AppCode] [varchar](200) NULL,
	[DynaFieldTS] [timestamp] NOT NULL,
	[GridColTitleTID] [int] NULL,
	[DisplayTextTID] [int] NULL,
 CONSTRAINT [PK_DynaField] PRIMARY KEY CLUSTERED 
(
	[DynaFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_DynaField_FieldName]    Script Date: 11/23/2011 13:27:59 ******/
CREATE NONCLUSTERED INDEX [IX_DynaField_FieldName] ON [dbo].[DynaField] 
(
	[FieldName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_DynaField_MaskName]    Script Date: 11/23/2011 13:27:59 ******/
CREATE NONCLUSTERED INDEX [IX_DynaField_MaskName] ON [dbo].[DynaField] 
(
	[MaskName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für DynaField Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaField', @level2type=N'COLUMN',@level2name=N'DynaFieldID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_DynaField_DynaMask) => DynaMask.MaskName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaField', @level2type=N'COLUMN',@level2name=N'MaskName'
GO

ALTER TABLE [dbo].[DynaField]  WITH CHECK ADD  CONSTRAINT [FK_DynaField_DynaMask] FOREIGN KEY([MaskName])
REFERENCES [dbo].[DynaMask] ([MaskName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[DynaField] CHECK CONSTRAINT [FK_DynaField_DynaMask]
GO


