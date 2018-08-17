CREATE TABLE [dbo].[FaBetreuungsinfo](
	[FaBetreuungsinfoID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[IndividualBehinderung] [text] NULL,
	[IndividualPersoenlichkeit] [text] NULL,
	[IndividualKommunikation] [text] NULL,
	[IndividualIntellektuell] [text] NULL,
	[IndividualMotorik] [text] NULL,
	[IndividualFreizeit] [text] NULL,
	[IndividualNotfallInfo] [text] NULL,
	[BetreuungVerhalten] [text] NULL,
	[BetreuungAngst] [text] NULL,
	[BetreuungSicherheit] [text] NULL,
	[BetreuungVerhindern] [text] NULL,
	[BetreuungMedizin] [text] NULL,
	[BetreuungMedikation] [text] NULL,
	[BetreuungErnaehrung] [text] NULL,
	[BetreuungTagesablauf] [text] NULL,
	[SelbstaendigMobilitaet] [text] NULL,
	[SelbstaendigKleiden] [text] NULL,
	[SelbstaendigNahrung] [text] NULL,
	[SelbstaendigGrundpflege] [text] NULL,
	[SelbstaendigToilette] [text] NULL,
	[SelbstaendigSchlaf] [text] NULL,
	[SelbstaendigVerschiedenes] [text] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[FaBetreuungsinfoTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaBetreuungsinfo] PRIMARY KEY CLUSTERED 
(
	[FaBetreuungsinfoID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'FaBetreuungsinfoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Behinderung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualBehinderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Persönlichkeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualPersoenlichkeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Kommunikation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualKommunikation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Intellektuelle Entwicklung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualIntellektuell'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Motorische Fähigkeiten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualMotorik'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Individualität - Freizeit, Interessen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'IndividualFreizeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Verhaltensstörung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungVerhalten'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Angstfaktoren' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungAngst'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Sicherheit gebende Elemente' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungSicherheit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Sollte verhindert werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungVerhindern'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Medizinisches, Behandlungspflege' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungMedizin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Medikation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungMedikation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Ernährung, Getränke' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungErnaehrung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreuung - Tagesablauf, Rhythmus' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'BetreuungTagesablauf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Mobilität' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigMobilitaet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - An-/Auskleiden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigKleiden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Nahrungsaufnahme' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigNahrung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Grundpflege' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigGrundpflege'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Toilette' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigToilette'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Schlaf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigSchlaf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Selbstständigkeit - Verschiedene Aktivitäten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'SelbstaendigVerschiedenes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaBetreuungsinfo', @level2type=N'COLUMN',@level2name=N'FaBetreuungsinfoTS'
GO

ALTER TABLE [dbo].[FaBetreuungsinfo]  WITH CHECK ADD  CONSTRAINT [FK_FaBetreuungsinfo_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaBetreuungsinfo] CHECK CONSTRAINT [FK_FaBetreuungsinfo_BaPerson]
GO

ALTER TABLE [dbo].[FaBetreuungsinfo] ADD  CONSTRAINT [DF_FaBetreuungsinfo_Created]  DEFAULT (getdate()) FOR [Created]
GO
