CREATE TABLE [dbo].[WshAbzugDetail](
	[WshAbzugDetailID] [int] IDENTITY(1,1) NOT NULL,
	[WshAbzugID] [int] NOT NULL,
	[KbuKontoID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[Betrag] [money] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshAbzugDetailTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshAbzugDetail] PRIMARY KEY CLUSTERED 
(
	[WshAbzugDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WshAbzugDetail_BaPersonID]    Script Date: 08/25/2011 17:41:08 ******/
CREATE NONCLUSTERED INDEX [IX_WshAbzugDetail_BaPersonID] ON [dbo].[WshAbzugDetail] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshAbzugDetail_KbuKontoID]    Script Date: 08/25/2011 17:41:08 ******/
CREATE NONCLUSTERED INDEX [IX_WshAbzugDetail_KbuKontoID] ON [dbo].[WshAbzugDetail] 
(
	[KbuKontoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_WshAbzugDetail_WshAbzugID]    Script Date: 08/25/2011 17:41:08 ******/
CREATE NONCLUSTERED INDEX [IX_WshAbzugDetail_WshAbzugID] ON [dbo].[WshAbzugDetail] 
(
	[WshAbzugID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'WshAbzugDetailID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf den zugehörigen WshAbzug-Eintrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'WshAbzugID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Konto/Kostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'KbuKontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die betroffene Person (NULL=UE)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Betrag des Abzugs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail', @level2type=N'COLUMN',@level2name=N'WshAbzugDetailTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detailpositionstabelle für Abzugspositionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshAbzugDetail'
GO

ALTER TABLE [dbo].[WshAbzugDetail]  WITH CHECK ADD  CONSTRAINT [FK_WshAbzugDetail_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshAbzugDetail] CHECK CONSTRAINT [FK_WshAbzugDetail_BaPerson]
GO

ALTER TABLE [dbo].[WshAbzugDetail]  WITH CHECK ADD  CONSTRAINT [FK_WshAbzugDetail_KbuKonto] FOREIGN KEY([KbuKontoID])
REFERENCES [dbo].[KbuKonto] ([KbuKontoID])
GO

ALTER TABLE [dbo].[WshAbzugDetail] CHECK CONSTRAINT [FK_WshAbzugDetail_KbuKonto]
GO

ALTER TABLE [dbo].[WshAbzugDetail]  WITH CHECK ADD  CONSTRAINT [FK_WshAbzugDetail_WshAbzug] FOREIGN KEY([WshAbzugID])
REFERENCES [dbo].[WshAbzug] ([WshAbzugID])
GO

ALTER TABLE [dbo].[WshAbzugDetail] CHECK CONSTRAINT [FK_WshAbzugDetail_WshAbzug]
GO

ALTER TABLE [dbo].[WshAbzugDetail] ADD  CONSTRAINT [DF_WshAbzugDetail_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshAbzugDetail] ADD  CONSTRAINT [DF_WshAbzugDetail_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

