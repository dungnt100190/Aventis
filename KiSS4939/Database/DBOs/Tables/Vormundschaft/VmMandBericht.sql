CREATE TABLE [dbo].[VmMandBericht](
	[VmMandBerichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[VmBerichtID] [int] NULL,
	[DocumentID] [int] NULL,
	[VmGrundMassnahmeCode] [int] NULL,
	[VmBerichtstitelCode] [int] NULL,
	[BerichtDatumVon] [datetime] NULL,
	[BerichtDatumBis] [datetime] NULL,
	[GrundMassnahmeText] [varchar](max) NULL,
	[AuftragZielsetzungText] [varchar](max) NULL,
	[VmZielErreichtCode] [int] NULL,
	[VeraenderungInPeriode] [bit] NOT NULL,
	[Begruendung] [varchar](max) NULL,
	[NeueZieleText] [varchar](max) NULL,
	[VmWohnenCode] [int] NULL,
	[VmGesundheitCode] [int] NULL,
	[VmVerhaltenCode] [int] NULL,
	[VmTaetigkeitCode] [int] NULL,
	[FamiliaereSituation] [bit] NOT NULL,
	[SozialeKompetenzen] [bit] NOT NULL,
	[Freizeit] [bit] NOT NULL,
	[Resourcen] [bit] NOT NULL,
	[WohnenText] [varchar](max) NULL,
	[GesundheitText] [varchar](max) NULL,
	[VerhaltenText] [varchar](max) NULL,
	[TaetigkeitText] [varchar](max) NULL,
	[FamSituationText] [varchar](max) NULL,
	[SozialeKompetenzenText] [varchar](max) NULL,
	[FreizeitText] [varchar](max) NULL,
	[BesondereRessourcenText] [varchar](max) NULL,
	[HandlungenText] [varchar](max) NULL,
	[BesondereSchwierigkeitenText] [varchar](max) NULL,
	[Klient] [bit] NOT NULL,
	[Dritte] [bit] NOT NULL,
	[Institutionen] [bit] NOT NULL,
	[KlientText] [varchar](max) NULL,
	[DritteText] [varchar](max) NULL,
	[InstitutionenText] [varchar](max) NULL,
	[VmBerichtBelastungsangabeMCSCCode_Mandat] [int] NULL,
	[VmBerichtBelastungsangabeMCSCCode_Admin] [int] NULL,
	[BelastungMandatText] [varchar](max) NULL,
	[BelastungAdminText] [varchar](max) NULL,
	[VmEinnahmenAngabenCodes] [varchar](255) NULL,
	[VmBerichtVersicherungenCodes] [varchar](255) NULL,
	[VmBerichtBesondereAngabenCodes] [varchar](255) NULL,
	[EinnahmenBemerkungen] [varchar](max) NULL,
	[VersicherungenBemerkungen] [varchar](max) NULL,
	[BesondereAngabenBemerkungen] [varchar](max) NULL,
	[AbrechnungUnterschrieben] [bit] NOT NULL,
	[PassationTeilnahme] [bit] NOT NULL,
	[PassationBemerkung] [varchar](max) NULL,
	[VmAntragBerichtCode] [int] NULL,
	[AntragBegruendung] [varchar](max) NULL,
	[ErstellungDatum] [datetime] NULL,
	[VmMfBerichtBeilagenCode] [int] NULL,
	[BsDatum] [datetime] NULL,
	[BelegeZurueckRevision] [datetime] NULL,
	[ZurueckVomBS] [datetime] NULL,
	[VmBerichtsartCode] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmMandBerichtTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmMandBericht] PRIMARY KEY CLUSTERED 
(
	[VmMandBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmMandBericht_FaLeistungID]    Script Date: 11/16/2010 08:38:23 ******/
CREATE NONCLUSTERED INDEX [IX_VmMandBericht_FaLeistungID] ON [dbo].[VmMandBericht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmMandBericht_UserId]    Script Date: 11/16/2010 08:38:23 ******/
CREATE NONCLUSTERED INDEX [IX_VmMandBericht_UserId] ON [dbo].[VmMandBericht] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_VmMandBericht_VmBerichtID]    Script Date: 11/16/2010 08:38:23 ******/
CREATE NONCLUSTERED INDEX [IX_VmMandBericht_VmBerichtID] ON [dbo].[VmMandBericht] 
(
	[VmBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmMandBericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmMandBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Autor des Antrag EKSK.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VmBericht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Document', @value=N'Id des physikalischen Dokuments.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beispiele: Neuerrichtung, Fortsetzung, Übernahme.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmGrundMassnahmeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art des Berichts, z.B. Beistandsschaftsbericht.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtstitelCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bericht für die Zeit ab Datum.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BerichtDatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bericht für die Zeit bis Datum.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BerichtDatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund der Massnahme / Anlassproblem (T)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'GrundMassnahmeText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Auftrag/Zielsetzung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'AuftragZielsetzungText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ziele erreicht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmZielErreichtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Veränderung innerhalb der Berichtsperiode, Ja' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VeraenderungInPeriode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung, warum Ziel nicht erreicht.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Begruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Neue Ziele ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'NeueZieleText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beispiele: eigene Wohung / Hotel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmWohnenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mögliche Werte: unauffällig, krank.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmGesundheitCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mögliche Werte: Auffällig, unauffällig, krank' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmVerhaltenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beispiele: Schule, Lehre' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmTaetigkeitCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Familiäre Situation' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'FamiliaereSituation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Soziale Kompetenzen (VJ).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'SozialeKompetenzen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripiton', @value=N'Freizeit / Interessen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Freizeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Besondere Ressourcen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Resourcen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Wohnsituation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'WohnenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Gesundheitliche Situation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'GesundheitText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des Verhaltens.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VerhaltenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Tätigkeiten (z.B. Lehre).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'TaetigkeitText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Familiäre Situation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'FamSituationText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die sozialen Kompetenzen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'SozialeKompetenzenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Freizeit.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'FreizeitText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die besonderen Resourcen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BesondereRessourcenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über die Handlungen und wichtigsten Aufgaben.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'HandlungenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung über besondere Schwirigkeiten.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BesondereSchwierigkeitenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Klient' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Klient'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Dritten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Dritte'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Institutionen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Institutionen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Klient Text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'KlientText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Dritte Text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'DritteText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kontakte/Gespräche mit (T), Institutionen Text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'InstitutionenText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wie aufwändig die Mandatsführung ist (Beispiele: normal, aufwändig, schwierig, sehr schwierig).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtBelastungsangabeMCSCCode_Mandat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'eispiele: normal, aufwändig, schwierig, sehr schwierig.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtBelastungsangabeMCSCCode_Admin'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belastung für die Mandatsführung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BelastungMandatText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belastung für den Administrator.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BelastungAdminText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einnahmen, z.B. Lohn, IV, AHV u.s.w.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmEinnahmenAngabenCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Versicherungen T, z.B. Krankenkasse.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtVersicherungenCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Besondere Angaben (T)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtBesondereAngabenCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu den Einnahmen (T).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'EinnahmenBemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu den Versicherungen (T)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VersicherungenBemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu den besonderen Angaben (T).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BesondereAngabenBemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abrechnung unterschreibbar Ja' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'AbrechnungUnterschrieben'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nimmt an Passation teil, Ja' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'PassationTeilnahme'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Bemerkungen zur Passation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'PassationBemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Antrag EKSK (Erwachsenen Kind Schutz Kommission): (T / VJ). Beispiele: Weiterführung, Aufhebung, Änderung der Massnahme.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmAntragBerichtCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begründung zum Antrag EKSK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'AntragBegruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Erstellungsdatum Antrag EKSK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'ErstellungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beilagen. Beispiele: Grundlageninventar, Grundlagenbericht, Erstbericht keine Grundlage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmMfBerichtBeilagenCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bericht Abrechnung & Belege an BS' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BsDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Belege zurück vom Revisor' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'BelegeZurueckRevision'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bericht zurück vom BS.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'ZurueckVomBS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Art des Berichts. Beipsiele: ordentlicher Bericht, Schlussbericht Todesfall.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht', @level2type=N'COLUMN',@level2name=N'VmMandBerichtTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Claude Glauser' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Berichte in der Vormundschaft (Vormundschaftliche Massnahme -> Mandatsführung -> Berichte).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMandBericht'
GO

ALTER TABLE [dbo].[VmMandBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmMandBericht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmMandBericht] CHECK CONSTRAINT [FK_VmMandBericht_FaLeistung]
GO

ALTER TABLE [dbo].[VmMandBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmMandBericht_VmBericht] FOREIGN KEY([VmBerichtID])
REFERENCES [dbo].[VmBericht] ([VmBerichtID])
GO

ALTER TABLE [dbo].[VmMandBericht] CHECK CONSTRAINT [FK_VmMandBericht_VmBericht]
GO

ALTER TABLE [dbo].[VmMandBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmMandBericht_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmMandBericht] CHECK CONSTRAINT [FK_VmMandBericht_XUser]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_VeraenderungInPeriode]  DEFAULT ((0)) FOR [VeraenderungInPeriode]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_FamiliaereSituation]  DEFAULT ((0)) FOR [FamiliaereSituation]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_SozialeKompetenzen]  DEFAULT ((0)) FOR [SozialeKompetenzen]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Freizeit]  DEFAULT ((0)) FOR [Freizeit]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Resourcen]  DEFAULT ((0)) FOR [Resourcen]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Klient]  DEFAULT ((0)) FOR [Klient]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Dritte]  DEFAULT ((0)) FOR [Dritte]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Institutionen]  DEFAULT ((0)) FOR [Institutionen]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_AbrechnungUnterschrieben]  DEFAULT ((0)) FOR [AbrechnungUnterschrieben]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_PassationTeilnahme]  DEFAULT ((0)) FOR [PassationTeilnahme]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmMandBericht] ADD  CONSTRAINT [DF_VmMandBericht_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


