CREATE TABLE [dbo].[GvPositionsart](
	[GvPositionsartID] [int] IDENTITY(1,1) NOT NULL,
	[GvPositionsartID_CopyOf] [int] NULL,
	[BgKostenartID] [int] NOT NULL,
	[Bezeichnung] [varchar](max) NULL,
	[BezeichnungTID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[HSOnly] [bit] NOT NULL,
	[IsFLB] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvPositionsartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvPositionsart] PRIMARY KEY CLUSTERED 
(
	[GvPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvPositionsart_BgKostenartID]    Script Date: 09/27/2013 14:04:04 ******/
CREATE NONCLUSTERED INDEX [IX_GvPositionsart_BgKostenartID] ON [dbo].[GvPositionsart] 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvPositionsart_GvPositionsartID_CopyOf]    Script Date: 09/27/2013 14:04:04 ******/
CREATE NONCLUSTERED INDEX [IX_GvPositionsart_GvPositionsartID_CopyOf] ON [dbo].[GvPositionsart] 
(
	[GvPositionsartID_Copyof] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvPositionsart Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'GvPositionsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvPositionsart_GvPositionsartID_CopyOf) => GvPositionsartID_CopyOf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'GvPositionsartID_Copyof'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvPositionsart_BgKostenart) => BgKostenartID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnung der GvPositionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID für die Übersetzung der Bezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'BezeichnungTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, ab wann die Positionsart gültig ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, bis wann die Positionsart gültig ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'DatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob es sich bei der Positionsart um eine für alle zugängliche oder eine nur für die Hauptstelle zugängliche handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'HSOnly'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob es sich bei der Positionsart um FLB oder eine interne nicht FLB handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'IsFLB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart', @level2type=N'COLUMN',@level2name=N'GvPositionsartTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu den einzelnen Positionsarten in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvPositionsart'
GO

ALTER TABLE [dbo].[GvPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_GvPositionsart_BgKostenart] FOREIGN KEY([BgKostenartID])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[GvPositionsart] CHECK CONSTRAINT [FK_GvPositionsart_BgKostenart]
GO

ALTER TABLE [dbo].[GvPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_GvPositionsart_GvPositionsart] FOREIGN KEY([GvPositionsartID])
REFERENCES [dbo].[GvPositionsart] ([GvPositionsartID])
GO

ALTER TABLE [dbo].[GvPositionsart] CHECK CONSTRAINT [FK_GvPositionsart_GvPositionsart]
GO

ALTER TABLE [dbo].[GvPositionsart]  WITH CHECK ADD  CONSTRAINT [FK_GvPositionsart_GvPositionsartID_CopyOf] FOREIGN KEY([GvPositionsartID_Copyof])
REFERENCES [dbo].[GvPositionsart] ([GvPositionsartID])
GO

ALTER TABLE [dbo].[GvPositionsart] CHECK CONSTRAINT [FK_GvPositionsart_GvPositionsartID_CopyOf]
GO

ALTER TABLE [dbo].[GvPositionsart] ADD  CONSTRAINT [DF_GvPositionsart_HSOnly]  DEFAULT ((0)) FOR [HSOnly]
GO

ALTER TABLE [dbo].[GvPositionsart] ADD  CONSTRAINT [DF_GvPositionsart_IsFLB]  DEFAULT ((0)) FOR [IsFLB]
GO

ALTER TABLE [dbo].[GvPositionsart] ADD  CONSTRAINT [DF_GvPositionsart_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvPositionsart] ADD  CONSTRAINT [DF_GvPositionsart_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
