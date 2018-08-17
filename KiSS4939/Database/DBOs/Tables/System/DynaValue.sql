CREATE TABLE [dbo].[DynaValue](
	[DynaValueID] [int] IDENTITY(1,1) NOT NULL,
	[FaPhaseID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[DynaFieldID] [int] NOT NULL,
	[Value] [sql_variant] NULL,
	[ValueText] [varchar](max) NULL,
	[GridRowID] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[DynaValueTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_DynaValue] PRIMARY KEY CLUSTERED 
(
	[DynaValueID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_DynaValue_DynaFieldID]    Script Date: 11/23/2011 14:39:06 ******/
CREATE NONCLUSTERED INDEX [IX_DynaValue_DynaFieldID] ON [dbo].[DynaValue] 
(
	[DynaFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_DynaValue_FaLeistungID]    Script Date: 11/23/2011 14:39:06 ******/
CREATE NONCLUSTERED INDEX [IX_DynaValue_FaLeistungID] ON [dbo].[DynaValue] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_DynaValue_FaLeistungID_DynaValueID_DynaFieldID_GridRowID]    Script Date: 11/23/2011 14:39:06 ******/
CREATE NONCLUSTERED INDEX [IX_DynaValue_FaLeistungID_DynaValueID_DynaFieldID_GridRowID] ON [dbo].[DynaValue] 
(
	[FaLeistungID] ASC,
	[DynaValueID] ASC,
	[DynaFieldID] ASC,
	[GridRowID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_DynaValue_FaPhaseID]    Script Date: 11/23/2011 14:39:06 ******/
CREATE NONCLUSTERED INDEX [IX_DynaValue_FaPhaseID] ON [dbo].[DynaValue] 
(
	[FaPhaseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für DynaValue Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaValue', @level2type=N'COLUMN',@level2name=N'DynaValueID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_DynaValue_FaPhase) => FaPhase.FaPhaseID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaValue', @level2type=N'COLUMN',@level2name=N'FaPhaseID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_DynaValue_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaValue', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_DynaValue_DynaField) => DynaField.DynaFieldID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DynaValue', @level2type=N'COLUMN',@level2name=N'DynaFieldID'
GO

ALTER TABLE [dbo].[DynaValue]  WITH CHECK ADD  CONSTRAINT [FK_DynaValue_DynaField] FOREIGN KEY([DynaFieldID])
REFERENCES [dbo].[DynaField] ([DynaFieldID])
GO

ALTER TABLE [dbo].[DynaValue] CHECK CONSTRAINT [FK_DynaValue_DynaField]
GO

ALTER TABLE [dbo].[DynaValue]  WITH CHECK ADD  CONSTRAINT [FK_DynaValue_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[DynaValue] CHECK CONSTRAINT [FK_DynaValue_FaLeistung]
GO

ALTER TABLE [dbo].[DynaValue]  WITH CHECK ADD  CONSTRAINT [FK_DynaValue_FaPhase] FOREIGN KEY([FaPhaseID])
REFERENCES [dbo].[FaPhase] ([FaPhaseID])
GO

ALTER TABLE [dbo].[DynaValue] CHECK CONSTRAINT [FK_DynaValue_FaPhase]
GO


