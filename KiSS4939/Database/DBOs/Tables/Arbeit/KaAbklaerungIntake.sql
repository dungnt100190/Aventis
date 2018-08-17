CREATE TABLE [dbo].[KaAbklaerungIntake](
	[KaAbklaerungIntakeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[KaAbklaerungPhaseIntakeCode] [int] NULL,
	[KaAbklaerungStatusDossierCode] [int] NULL,
	[AsdFragen] [varchar](max) NULL,
	[Gespraechstermin] [datetime] NULL,
	[KaAbklaerungPraesenzCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[DatumIntegration] [datetime] NULL,
	[KaAbklaerungIntegrBeurCode] [int] NULL,
	[KaAbklaerungGrundDossCode] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[DocumentID_Integration] [int] NULL,
	[DocumentID_FormularAsD] [int] NULL,
	[DocumentID_ZusammenfassungEG] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaAbklaerungIntakeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAbklaerungIntake] PRIMARY KEY CLUSTERED 
(
	[KaAbklaerungIntakeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaAbklaerungIntake_FaLeistungID] ON [dbo].[KaAbklaerungIntake] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaAbklaerungIntake Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'KaAbklaerungIntakeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaAbklaerungIntake_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld Modul' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'KaAbklaerungPhaseIntakeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld Status Dossier' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'KaAbklaerungStatusDossierCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV KaAbklärungGrundDoss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'KaAbklaerungGrundDossCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake', @level2type=N'COLUMN',@level2name=N'KaAbklaerungIntakeTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'KA - Abklärung - Intake' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaAbklaerungIntake'
GO

ALTER TABLE [dbo].[KaAbklaerungIntake]  WITH CHECK ADD  CONSTRAINT [FK_KaAbklaerungIntake_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaAbklaerungIntake] CHECK CONSTRAINT [FK_KaAbklaerungIntake_FaLeistung]
GO

ALTER TABLE [dbo].[KaAbklaerungIntake] ADD  CONSTRAINT [DF_KaAbklaerungIntake_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaAbklaerungIntake] ADD  CONSTRAINT [DF_KaAbklaerungIntake_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaAbklaerungIntake] ADD  CONSTRAINT [DF_KaAbklaerungIntake_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


