-- wird temporär noch verwendet um manuell Zahlungsege zu migrieren
CREATE TABLE [dbo].[FlZahlungsweg](
	[FlZahlungswegID] [int] NOT NULL,
	[FlKreditorID] [int] NOT NULL,
	[BankName] [varchar](50) NULL,
	[BankKontoNr] [varchar](50) NULL,
	[BankPcKonto] [varchar](50) NULL,
	[EsrTeilnehmer] [varchar](50) NULL,
	[Strasse] [varchar](50) NULL,
	[PLZ] [varchar](8) NULL,
	[Ort] [varchar](50) NULL,
	[Clearing] [varchar](10) NULL,
	[Kontoart] [varchar](4) NULL,
	[FlZahlungswegTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlZahlungsweg] PRIMARY KEY NONCLUSTERED 
(
	[FlZahlungswegID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_FlZahlungsweg] ON [dbo].[FlZahlungsweg] 
(
	[FlKreditorID] ASC,
	[BankName] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[FlZahlungsweg]  WITH CHECK ADD  CONSTRAINT [FK_tcoKissFbZahlungsweg_tcoKissFbKreditor] FOREIGN KEY([FlKreditorID])
REFERENCES [FlKreditor] ([FlKreditorID])
GO

ALTER TABLE [dbo].[FlZahlungsweg] CHECK CONSTRAINT [FK_tcoKissFbZahlungsweg_tcoKissFbKreditor]
GO