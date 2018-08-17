CREATE TABLE [dbo].[Hist_BDELeistungsart](
	[BDELeistungsartID] [int] NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[SortKey] [int] NULL,
	[KlientErfassungCode] [int] NULL,
	[AnzahlCode] [int] NULL,
	[ArtikelNr] [varchar](50) NULL,
	[LeistungsartTypCode] [int] NOT NULL,
	[KostenartCode] [int] NULL,
	[KTRStandard] [varchar](20) NULL,
	[KTRIV] [varchar](20) NULL,
	[KTRAHV] [varchar](20) NULL,
	[KTRNichtberechtigte] [varchar](20) NULL,
	[Beschreibung] [varchar](1000) NULL,
	[AuswDienstleistungCode] [int] NULL,
	[AuswFakturaCode] [int] NULL,
	[AuswProduktCode] [int] NULL,
	[AuswPIAuftragCode] [int] NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BDELeistungsart] PRIMARY KEY CLUSTERED 
(
	[BDELeistungsartID] ASC,
	[VerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO