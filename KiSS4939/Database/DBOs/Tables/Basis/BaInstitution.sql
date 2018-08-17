CREATE TABLE [dbo].[BaInstitution](
	[BaInstitutionID] [int] IDENTITY(1,1) NOT NULL,
	[OrgUnitID] [int] NULL,
	[InstitutionNr] [varchar](20) NULL,
	[BaInstitutionArtCode] [int] NULL,
	[Aktiv] [bit] NOT NULL,
	[Debitor] [bit] NOT NULL,
	[Kreditor] [bit] NOT NULL,
	[KeinSerienbrief] [bit] NOT NULL,
	[ManuelleAnrede] [bit] NOT NULL,
	[Anrede] [varchar](100) NULL,
	[Briefanrede] [varchar](100) NULL,
	[Titel] [varchar](100) NULL,
	[Name] [varchar](500) NULL,
	[Vorname] [varchar](100) NULL,
	[GeschlechtCode] [int] NULL,
	[Geburtsdatum] [datetime] NULL,
	[Versichertennummer] [varchar](18) NULL,
	[Telefon] [varchar](100) NULL,
	[Telefon2] [varchar](100) NULL,
	[Telefon3] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[Homepage] [varchar](100) NULL,
	[SprachCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[InstitutionName] [varchar](100) NULL,
	[InstitutionTypCode] [int] NULL,
	[BaFreigabeStatusCode] [int] NULL,
	[DefinitivUserID] [int] NULL,
	[DefinitivDatum] [datetime] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[Creator] [varchar](50) NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NULL,
	[Modified] [datetime] NOT NULL,
	[BaInstitutionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitution] PRIMARY KEY CLUSTERED 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_BaInstitution_BaInstitutionID__AddCols]    Script Date: 02/27/2014 13:24:50 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitution_BaInstitutionID__AddCols] ON [dbo].[BaInstitution] 
(
	[BaInstitutionID] ASC
)
INCLUDE ( [Name],
[Vorname]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO


/****** Object:  Index [IX_BaInstitution_BaInstitutionID_Name_Vorname]    Script Date: 02/27/2014 13:24:50 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitution_BaInstitutionID_Name_Vorname] ON [dbo].[BaInstitution] 
(
	[BaInstitutionID] ASC,
	[Name] ASC,
	[Vorname] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO


/****** Object:  Index [IX_BaInstitution_InstitutionName]    Script Date: 02/27/2014 13:24:50 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitution_InstitutionName] ON [dbo].[BaInstitution] 
(
	[InstitutionName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaInstitution_Name]    Script Date: 02/27/2014 13:24:50 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitution_Name] ON [dbo].[BaInstitution] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO


/****** Object:  Index [IX_BaInstitution_OrgUnitID]    Script Date: 02/27/2014 13:24:50 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitution_OrgUnitID] ON [dbo].[BaInstitution] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaInstitution Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XOrgUnit.OrgUnitID, um einer Institution eine Abteilung als Besitzer zuzuweisen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nummer der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'InstitutionNr'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'TODO wozu wird die gebraucht???' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'InstitutionNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art der Institution anhand der Werteliste BaInstitutionArt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionArtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Institution aktiv ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Aktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Institution ein Debitor ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Debitor'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'TODO ??? wozu wird dies gebraucht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Debitor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Institution ein Kreditor ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Kreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'TODO ??? wozu wird dies gebraucht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Kreditor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Institution Serienbriefe erhalten soll oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'KeinSerienbrief'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Anrede manuell oder automatisch erzeugt wird. Bei der manuellen Anrede kommen die Felder Anrede und Briefanrede zur Geltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'ManuelleAnrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anrede der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Anrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Briefanrede der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Briefanrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Titel der Institution, sofern die Institution eine Fachperson ist (abhängig vom ByInstitutionTypCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Titel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Institution (Mehrzeilig) oder Name der Fachperson (Einzeilig)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vorname der Institution, sofern die Institution eine Fachperson ist (abhängig vom ByInstitutionTypCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Vorname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geschlecht der Institution, sofern die Institution eine Fachperson ist (abhängig vom ByInstitutionTypCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'GeschlechtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geburtsdatum einer Fachperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Geburtsdatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Versichertennummer einer Fachperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Versichertennummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telefon-Nummer der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Telefon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zweite Telefon-Nummer der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Telefon2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Dritte Telefon-Nummer der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Telefon3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fax-Nummer der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Mail Adresse der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'EMail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Homepage der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Homepage'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'Deutsch, Französisch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'SprachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Korrespondenzsprache der Institution' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'SprachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'LOVName: Sprache' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'SprachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'RTF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitution', @level2type=N'COLUMN',@level2name=N'BaInstitutionTS'
GO

ALTER TABLE [dbo].[BaInstitution]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitution_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[BaInstitution] CHECK CONSTRAINT [FK_BaInstitution_XOrgUnit]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_Aktiv]  DEFAULT ((1)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_Debitor]  DEFAULT ((0)) FOR [Debitor]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_Kreditor]  DEFAULT ((0)) FOR [Kreditor]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_KeinSerienbrief]  DEFAULT ((0)) FOR [KeinSerienbrief]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_ManuelleAnrede]  DEFAULT ((0)) FOR [ManuelleAnrede]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaInstitution] ADD  CONSTRAINT [DF_BaInstitution_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

