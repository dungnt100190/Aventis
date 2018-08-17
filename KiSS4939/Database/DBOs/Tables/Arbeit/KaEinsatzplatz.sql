CREATE TABLE [dbo].[KaEinsatzplatz] (
	[KaEinsatzplatzID] [int] IDENTITY (1, 1) NOT NULL ,
	[Bezeichnung] [varchar] (200) NULL ,
	[BrancheCode] [int] NULL ,
	[KaBetriebID] [int] NULL ,
	[Aktiv] [bit] NOT NULL CONSTRAINT [DF_KaEinsatzplatz_Aktiv] DEFAULT (1),
	[KaProgrammCode] [int] NULL ,
	[ZustaendigKA] [int] NULL ,
	[LehrberufCode] [int] NULL ,
	[BerufsAusbildungTyp] [int] NULL ,
	[NeuGeschaffeneLehrstelle] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_NeuGeschaffeneLehrstelle] DEFAULT (0),
	[Details] [varchar] (2000) NULL ,
	[ErfassungsDatum] [datetime] NULL ,
	[EinsatzAb] [datetime] NULL ,
	[DauerUnbefristet] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_DauerUnbefristet] DEFAULT (0),
	[GesamtPensum] [int] NULL ,
	[PensumAufteilbar] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_PensumAufteilbar] DEFAULT (0),
	[EinzelpensumMinimum] [int] NULL ,
	[EinzelpensumMaximum] [int] NULL ,
	[PensumUnbestimmt] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_PensumUnbestimmt] DEFAULT (0),
	[Fuehrerausweis] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_Fuehrerausweis] DEFAULT (0),
	[FuehrerausweisKategorieCode] [int] NULL ,
	[PCKenntnisse] [bit] NULL CONSTRAINT [DF_KaEinsatzplatz_PCKenntnisse] DEFAULT (0),
	[GeschlechtCode] [int] NULL ,
	[DeutschMuendlichCode] [int] NULL ,
	[DeutschSchriftlichCode] [int] NULL ,
	[AusbildungCode] [int] NULL ,
	[WeitereAnforderungen] [varchar] (2000) NULL ,
	[KaKontaktpersonID] [int] NULL ,
	[FunktionCode] [int] NULL ,
	[Bemerkung] [varchar] (2000) NULL ,
	[KaEinsatzplatzTS] [timestamp] NOT NULL ,
	[MigrationKA] [int] NULL CONSTRAINT [DF_KaEinsatzplatz_MigrationKA] DEFAULT (0),
	CONSTRAINT [PK_KaEinsatzplatz] PRIMARY KEY  Clustered
	(
		[KaEinsatzplatzID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_KaEinsatzplatz_KaBetrieb] FOREIGN KEY
	(
		[KaBetriebID]
	) REFERENCES [dbo].[KaBetrieb] (
		[KaBetriebID]
	),
	CONSTRAINT [FK_KaEinsatzplatz_KaBetriebKontakt] FOREIGN KEY
	(
		[KaKontaktpersonID]
	) REFERENCES [dbo].[KaBetriebKontakt] (
		[KaBetriebKontaktID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KaEinsatzplatz_KaBetriebID] ON [dbo].[KaEinsatzplatz]([KaBetriebID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_KaEinsatzplatz_KaKontaktpersonID] ON [dbo].[KaEinsatzplatz]([KaKontaktpersonID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaEinsatzplatz Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaEinsatzplatz', N'column', N'KaEinsatzplatzID'
GO

GO

GO

GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaEinsatzplatz_KaBetrieb) => KaBetrieb.KaBetriebID', N'user', N'dbo', N'table', N'KaEinsatzplatz', N'column', N'KaBetriebID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaEinsatzplatz_KaBetriebKontakt) => KaBetriebKontakt.KaBetriebKontaktID', N'user', N'dbo', N'table', N'KaEinsatzplatz', N'column', N'KaKontaktpersonID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
