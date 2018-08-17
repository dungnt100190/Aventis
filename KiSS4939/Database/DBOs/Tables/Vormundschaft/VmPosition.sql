CREATE TABLE [dbo].[VmPosition](
	[VmPositionID] [int] IDENTITY(1,1) NOT NULL,
	[VmKlientenbudgetID] [int] NOT NULL,
	[VmPositionsartID] [int] NOT NULL,
	[IstImportiert] [bit] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Bemerkung] [varchar](1000) NULL,
	[DatumSaldoPer] [datetime] NULL,
	[Saldo] [money] NULL,
	[BetragMonatlich] [money] NULL,
	[BetragJaehrlich] [money] NULL,
	[SortKey] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmPositionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmPosition] PRIMARY KEY CLUSTERED 
(
	[VmPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmPosition_VmKlientenbudgetID]    Script Date: 04/12/2012 16:23:27 ******/
CREATE NONCLUSTERED INDEX [IX_VmPosition_VmKlientenbudgetID] ON [dbo].[VmPosition] 
(
	[VmKlientenbudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmPosition_VmPositionsartID]    Script Date: 04/12/2012 16:23:27 ******/
CREATE NONCLUSTERED INDEX [IX_VmPosition_VmPositionsartID] ON [dbo].[VmPosition] 
(
	[VmPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'VmPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VmKlientenbudget' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'VmKlientenbudgetID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VmPositionsart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'VmPositionsartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zum wissen ob die Daten dieser Position importiert werden sind' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'IstImportiert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung der Position' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum per des Saldos (für Kategorie Vermögen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'DatumSaldoPer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Saldo des Vermögens' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Saldo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Monatlicher Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'BetragMonatlich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jährlicher Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'BetragJaehrlich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erlaubt die Sortierung innerhalb einer Kategorie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'SortKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition', @level2type=N'COLUMN',@level2name=N'VmPositionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um Positionen in Klientenbudgets zu erfassen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmPosition'
GO

ALTER TABLE [dbo].[VmPosition]  WITH CHECK ADD  CONSTRAINT [FK_VmPosition_VmKlientenbudget] FOREIGN KEY([VmKlientenbudgetID])
REFERENCES [dbo].[VmKlientenbudget] ([VmKlientenbudgetID])
GO

ALTER TABLE [dbo].[VmPosition] CHECK CONSTRAINT [FK_VmPosition_VmKlientenbudget]
GO

ALTER TABLE [dbo].[VmPosition]  WITH CHECK ADD  CONSTRAINT [FK_VmPosition_VmPositionsart] FOREIGN KEY([VmPositionsartID])
REFERENCES [dbo].[VmPositionsart] ([VmPositionsartID])
GO

ALTER TABLE [dbo].[VmPosition] CHECK CONSTRAINT [FK_VmPosition_VmPositionsart]
GO

ALTER TABLE [dbo].[VmPosition] ADD  CONSTRAINT [DF_VmPosition_IstImportiert]  DEFAULT ((0)) FOR [IstImportiert]
GO

ALTER TABLE [dbo].[VmPosition] ADD  CONSTRAINT [DF_VmPosition_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmPosition] ADD  CONSTRAINT [DF_VmPosition_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

