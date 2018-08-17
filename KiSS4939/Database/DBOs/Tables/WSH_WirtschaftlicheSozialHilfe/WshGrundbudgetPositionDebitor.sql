CREATE TABLE [dbo].[WshGrundbudgetPositionDebitor](
	[WshGrundbudgetPositionDebitorID] [int] IDENTITY(1,1) NOT NULL,
	[WshGrundbudgetPositionID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshGrundbudgetPositionDebitorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshGrundbudgetPositionDebitor] PRIMARY KEY CLUSTERED 
(
	[WshGrundbudgetPositionDebitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_WshGrundbudgetPositionDebitor_WshGrundbudgetPositionID] UNIQUE NONCLUSTERED 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPositionDebitor_BaInstitutionID] ON [dbo].[WshGrundbudgetPositionDebitor] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPositionDebitor_BaPersonID] ON [dbo].[WshGrundbudgetPositionDebitor] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshGrundbudgetPositionDebitor_WshGrundbudgetPositionID] ON [dbo].[WshGrundbudgetPositionDebitor] 
(
	[WshGrundbudgetPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionDebitorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der GrundbudgetPosition, zu welcher die Debitor-Informationen gehören' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Institution, welche als Debitor verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Person, welche als Debitor verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshGrundbudgetPositionDebitorTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Debitor-Informationen der zugehörigen WshGrundbudgetPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor'
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPositionDebitor_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] CHECK CONSTRAINT [FK_WshGrundbudgetPositionDebitor_BaInstitution]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPositionDebitor_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] CHECK CONSTRAINT [FK_WshGrundbudgetPositionDebitor_BaPerson]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshGrundbudgetPositionDebitor_WshGrundbudgetPosition] FOREIGN KEY([WshGrundbudgetPositionID])
REFERENCES [dbo].[WshGrundbudgetPosition] ([WshGrundbudgetPositionID])
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] CHECK CONSTRAINT [FK_WshGrundbudgetPositionDebitor_WshGrundbudgetPosition]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor]  WITH CHECK ADD  CONSTRAINT [CK_WshGrundbudgetPositionDebitor_BaInstitutionID_OR_BaPersonID] CHECK  (([BaInstitutionID] IS NULL AND [BaPersonID] IS NOT NULL OR [BaInstitutionID] IS NOT NULL AND [BaPersonID] IS NULL))
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] CHECK CONSTRAINT [CK_WshGrundbudgetPositionDebitor_BaInstitutionID_OR_BaPersonID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sicherstellen, dass BaInstitutionID oder BaPersonID ausgefüllt ist und nur einer der beiden IDs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshGrundbudgetPositionDebitor', @level2type=N'CONSTRAINT',@level2name=N'CK_WshGrundbudgetPositionDebitor_BaInstitutionID_OR_BaPersonID'
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] ADD  CONSTRAINT [DF_WshGrundbudgetPositionDebitor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshGrundbudgetPositionDebitor] ADD  CONSTRAINT [DF_WshGrundbudgetPositionDebitor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO