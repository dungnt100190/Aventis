CREATE TABLE [dbo].[FsReduktionMitarbeiter](
	[FsReduktionMitarbeiterID] [int] IDENTITY(1,1) NOT NULL,
	[FsReduktionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[OriginalReduktionZeit] [money] NOT NULL,
	[AngepassteReduktionZeit] [money] NULL,
	[Monat] [int] NOT NULL,
	[Jahr] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FsReduktionMitarbeiterTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FsReduktionMitarbeiter] PRIMARY KEY CLUSTERED 
(
	[FsReduktionMitarbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FsReduktionMitarbeiter_FsReduktionID]    Script Date: 04/15/2011 16:23:11 ******/
CREATE NONCLUSTERED INDEX [IX_FsReduktionMitarbeiter_FsReduktionID] ON [dbo].[FsReduktionMitarbeiter] 
(
	[FsReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FsReduktionMitarbeiter_UserID]    Script Date: 04/15/2011 16:23:11 ******/
CREATE NONCLUSTERED INDEX [IX_FsReduktionMitarbeiter_UserID] ON [dbo].[FsReduktionMitarbeiter] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [UX_FsReduktionMitarbeiter_UserId_Jahr_Monat_FsReduktionId]    Script Date: 04/15/2011 16:23:11 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_FsReduktionMitarbeiter_UserId_Jahr_Monat_FsReduktionId] ON [dbo].[FsReduktionMitarbeiter] 
(
	[UserID] ASC,
	[Jahr] ASC,
	[Monat] ASC,
	[FsReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'FsReduktionMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Tabelle FsReduktion' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'FsReduktionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Tabelle XUser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Zeit aus dem zugrundeliegenden Reduktion. Einheit: Stunden pro Monat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'OriginalReduktionZeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die für diesen User angepasste Zeit des Reduktions. Einheit: Stunden pro Monat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'AngepassteReduktionZeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Monat für welcher dieser Reduktion gültig ist. Einheit: Stunden pro Monat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Monat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Jahr als Teil des Zeitraums in welchem der Reduktion gültig ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Jahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'COLUMN',@level2name=N'FsReduktionMitarbeiterTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Sam Psota' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Speichern der ReduktionZeiten pro User' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Fallsteuerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter'
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_FsReduktionMitarbeiter_FsReduktion] FOREIGN KEY([FsReduktionID])
REFERENCES [dbo].[FsReduktion] ([FsReduktionID])
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter] CHECK CONSTRAINT [FK_FsReduktionMitarbeiter_FsReduktion]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf Reduktionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'CONSTRAINT',@level2name=N'FK_FsReduktionMitarbeiter_FsReduktion'
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_FsReduktionMitarbeiter_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter] CHECK CONSTRAINT [FK_FsReduktionMitarbeiter_XUser]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf User' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FsReduktionMitarbeiter', @level2type=N'CONSTRAINT',@level2name=N'FK_FsReduktionMitarbeiter_XUser'
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter] ADD  CONSTRAINT [DF_FsReduktionMitarbeiter_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FsReduktionMitarbeiter] ADD  CONSTRAINT [DF_FsReduktionMitarbeiter_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


