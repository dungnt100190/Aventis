CREATE TABLE [dbo].[BaInstitutionKontakt](
	[BaInstitutionKontaktID] [int] IDENTITY(1,1) NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[ManuelleAnrede] [bit] NOT NULL,
	[Anrede] [varchar](100) NULL,
	[Briefanrede] [varchar](255) NULL,
	[Titel] [varchar](100) NULL,
	[Name] [varchar](100) NOT NULL,
	[Vorname] [varchar](100) NULL,
	[GeschlechtCode] [int] NULL,
	[Telefon] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[SprachCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaInstitutionKontaktTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitutionKontakt] PRIMARY KEY CLUSTERED 
(
	[BaInstitutionKontaktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaInstitutionKontakt_BaInstitutionID] ON [dbo].[BaInstitutionKontakt] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaInstitutionKontakt Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'BaInstitutionKontaktID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: BaInstitutionKontakt.BaInstitutionID => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob eine Kontaktperson aktiv ist oder nicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Aktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Anrede manuell oder automatisch erzeugt wird. Bei der manuellen Anrede kommen die Felder Anrede und Briefanrede zur Geltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'ManuelleAnrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Anrede der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Anrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Briefanrede der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Briefanrede'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Titel der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Titel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vorname der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Vorname'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Geschlecht der Kontaktperson (LOVName: Geschlecht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'GeschlechtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telefon-Nr. der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Telefon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fax-Nr. der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Mail Adresse der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'EMail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sprachcode der Kontaktperson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'SprachCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungsfeld' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'RTF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt', @level2type=N'COLUMN',@level2name=N'BaInstitutionKontaktTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi (Anpassungen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Institutionen können 0:n Kontaktpersonen zugewiesen werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Basis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaInstitutionKontakt'
GO

ALTER TABLE [dbo].[BaInstitutionKontakt]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionKontakt_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaInstitutionKontakt] CHECK CONSTRAINT [FK_BaInstitutionKontakt_BaInstitution]
GO

ALTER TABLE [dbo].[BaInstitutionKontakt] ADD  CONSTRAINT [DF_BaInstitutionKontakt_Aktiv]  DEFAULT ((0)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[BaInstitutionKontakt] ADD  CONSTRAINT [DF_BaInstitutionKontakt_ManuelleAnrede]  DEFAULT ((0)) FOR [ManuelleAnrede]
GO

ALTER TABLE [dbo].[BaInstitutionKontakt] ADD  CONSTRAINT [DF_BaInstitutionKontakt_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaInstitutionKontakt] ADD  CONSTRAINT [DF_BaInstitutionKontakt_Modified]  DEFAULT (getdate()) FOR [Modified]
GO