CREATE TABLE [Kiss3].[tspGetKontoauszug](
	[tspGetKontoauszugID] [int] IDENTITY(1,1) NOT NULL,
	[KbBuchungID] [int] NULL,
	[Typ] [varchar](50) NULL,
	[BelegNr] [int] NULL,
	[Datum] [datetime] NULL,
	[DatumForderung] [datetime] NULL,
	[Glaeubiger] [varchar](100) NULL,
	[Schuldner] [varchar](100) NULL,
	[Text] [varchar](200) NULL,
	[BetragSoll] [money] NULL,
	[BetragHaben] [money] NULL,
	[SollKto] [varchar](10) NULL,
	[HabenKto] [varchar](10) NULL,
	[Saldo] [money] NULL,
	[KbOpAusgleichID] [int] NULL,
	[BaPersonID] [int] NULL,
	[FaLeistungID] [int] NULL,
	[Einmalig] [bit] NULL,
	[Einnahmen] [bit] NULL,
 CONSTRAINT [PK_tspGetKontoauszugID] PRIMARY KEY NONCLUSTERED 
(
	[tspGetKontoauszugID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE NONCLUSTERED INDEX [IX_Einmalig] ON [Kiss3].[tspGetKontoauszug] 
(
	[Einmalig] ASC
) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaLeistungID] ON [Kiss3].[tspGetKontoauszug] 
(
	[FaLeistungID] ASC
) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_KbBuchungID] ON [Kiss3].[tspGetKontoauszug] 
(
	[KbBuchungID] ASC
) ON [PRIMARY]
GO