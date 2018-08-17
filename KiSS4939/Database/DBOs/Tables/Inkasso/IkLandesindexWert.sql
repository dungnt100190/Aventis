CREATE TABLE [dbo].[IkLandesindexWert](
	[IkLandesindexWertID] [int] IDENTITY(1,1) NOT NULL,
	[IkLandesindexID] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[Monat] [int] NOT NULL,
	[Wert] [money] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkLandesindexWertTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkLandesindexWert] PRIMARY KEY CLUSTERED 
(
	[IkLandesindexWertID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2],
 CONSTRAINT [UK_IkLandesindexWert_IkLandesindexID_Jahr_Monat] UNIQUE NONCLUSTERED 
(
	[IkLandesindexID] ASC,
	[Jahr] ASC,
	[Monat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkLandesindexWert_IkLandesindexID] ON [dbo].[IkLandesindexWert] 
(
	[IkLandesindexID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_IkLandesindexWert_IkLandesindexID_Jahr_Monat_Wert] ON [dbo].[IkLandesindexWert] 
(
	[IkLandesindexID] ASC,
	[Jahr] ASC,
	[Monat] ASC,
	[Wert] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'IkLandesindexWertID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf den verwendeten Landesindex (IkLandesindex.IkLandesindexID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'IkLandesindexID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Jahr, für welches der gegebene Wert gilt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Jahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Monat innerhalb des Jahres, für welches der gegebene Wert gilt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Monat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Wert für einen bestimmten Monat basierend auf einem IkLandesindex' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Wert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'COLUMN',@level2name=N'IkLandesindexWertTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die einzelnen Werte pro Monat und Jahr je Inkasso-Landesindex' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Inkasso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Pro Jahr und Monat darf je Landesindex nur ein Wert definiert sein' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'CONSTRAINT',@level2name=N'UK_IkLandesindexWert_IkLandesindexID_Jahr_Monat'
GO

ALTER TABLE [dbo].[IkLandesindexWert]  WITH CHECK ADD  CONSTRAINT [FK_IkLandesindexWert_IkLandesindex] FOREIGN KEY([IkLandesindexID])
REFERENCES [dbo].[IkLandesindex] ([IkLandesindexID])
GO

ALTER TABLE [dbo].[IkLandesindexWert] CHECK CONSTRAINT [FK_IkLandesindexWert_IkLandesindex]
GO

ALTER TABLE [dbo].[IkLandesindexWert]  WITH CHECK ADD  CONSTRAINT [CK_IkLandesindexWert_Jahr] CHECK  (([Jahr]>=(1753) AND [Jahr]<=(9999)))
GO

ALTER TABLE [dbo].[IkLandesindexWert] CHECK CONSTRAINT [CK_IkLandesindexWert_Jahr]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es muss ein gültiges SQL-DateTime-Jahr angegeben werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'CONSTRAINT',@level2name=N'CK_IkLandesindexWert_Jahr'
GO

ALTER TABLE [dbo].[IkLandesindexWert]  WITH CHECK ADD  CONSTRAINT [CK_IkLandesindexWert_Monat] CHECK  (([Monat]>=(1) AND [Monat]<=(12)))
GO

ALTER TABLE [dbo].[IkLandesindexWert] CHECK CONSTRAINT [CK_IkLandesindexWert_Monat]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es muss ein gültiger Monat angegeben werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkLandesindexWert', @level2type=N'CONSTRAINT',@level2name=N'CK_IkLandesindexWert_Monat'
GO

ALTER TABLE [dbo].[IkLandesindexWert] ADD  CONSTRAINT [DF_IkLandesindexWert_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkLandesindexWert] ADD  CONSTRAINT [DF_IkLandesindexWert_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

