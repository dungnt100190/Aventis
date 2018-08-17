CREATE TABLE [dbo].[WshPositionDebitor](
	[WshPositionDebitorID] [int] IDENTITY(1,1) NOT NULL,
	[WshPositionID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WshPositionDebitorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WshPositionDebitor] PRIMARY KEY CLUSTERED 
(
	[WshPositionDebitorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3],
 CONSTRAINT [UK_WshPositionDebitor_WshPositionID] UNIQUE NONCLUSTERED 
(
	[WshPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_WshPositionDebitor_BaInstitutionID] ON [dbo].[WshPositionDebitor] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshPositionDebitor_BaPersonID] ON [dbo].[WshPositionDebitor] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_WshPositionDebitor_WshPositionID] ON [dbo].[WshPositionDebitor] 
(
	[WshPositionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshPositionDebitorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Position, zu welcher die Debitor-Informationen gehören' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshPositionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Institution, welche als Debitor verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Person, welche als Debitor verwendet werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'COLUMN',@level2name=N'WshPositionDebitorTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Debitor-Informationen der zugehörigen WshPosition' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'WSH' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor'
GO

ALTER TABLE [dbo].[WshPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshPositionDebitor_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[WshPositionDebitor] CHECK CONSTRAINT [FK_WshPositionDebitor_BaInstitution]
GO

ALTER TABLE [dbo].[WshPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshPositionDebitor_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[WshPositionDebitor] CHECK CONSTRAINT [FK_WshPositionDebitor_BaPerson]
GO

ALTER TABLE [dbo].[WshPositionDebitor]  WITH CHECK ADD  CONSTRAINT [FK_WshPositionDebitor_WshPosition] FOREIGN KEY([WshPositionID])
REFERENCES [dbo].[WshPosition] ([WshPositionID])
GO

ALTER TABLE [dbo].[WshPositionDebitor] CHECK CONSTRAINT [FK_WshPositionDebitor_WshPosition]
GO

ALTER TABLE [dbo].[WshPositionDebitor]  WITH CHECK ADD  CONSTRAINT [CK_WshPositionDebitor_BaInstitutionID_OR_BaPersonID] CHECK  (([BaInstitutionID] IS NULL AND [BaPersonID] IS NOT NULL OR [BaInstitutionID] IS NOT NULL AND [BaPersonID] IS NULL))
GO

ALTER TABLE [dbo].[WshPositionDebitor] CHECK CONSTRAINT [CK_WshPositionDebitor_BaInstitutionID_OR_BaPersonID]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sicherstellen, dass BaInstitutionID oder BaPersonID ausgefüllt ist und nur eine der beiden IDs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WshPositionDebitor', @level2type=N'CONSTRAINT',@level2name=N'CK_WshPositionDebitor_BaInstitutionID_OR_BaPersonID'
GO

ALTER TABLE [dbo].[WshPositionDebitor] ADD  CONSTRAINT [DF_WshPositionDebitor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WshPositionDebitor] ADD  CONSTRAINT [DF_WshPositionDebitor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

