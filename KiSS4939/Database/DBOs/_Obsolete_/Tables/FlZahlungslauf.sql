-- wird temporär noch verwendet um manuell Zahlungsege zu migrieren
CREATE TABLE [dbo].[FlZahlungslauf](
	[FlZahlungslaufID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ymDatumZahlungslauf] [int] NOT NULL,
	[GeneriertAm] [datetime] NOT NULL,
	[FlTypZahlungslaufID] [int] NOT NULL,
	[Buchungstext] [varchar](120) NOT NULL,
	[Buchungsdatum] [datetime] NOT NULL,
	[Verfalldatum] [datetime] NOT NULL,
	[IsAutoBelNr] [bit] NOT NULL CONSTRAINT [DF_tdfKissFbZahlungslauf_IsAutoBelNr]  DEFAULT (0),
	[Belegnummer] [varchar](12) NOT NULL,
	[Bemerkung] [text] NULL,
	[FlZahlungslaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FlZahlungslauf] PRIMARY KEY NONCLUSTERED 
(
	[FlZahlungslaufID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE UNIQUE CLUSTERED INDEX [IX_FlZahlungslauf] ON [dbo].[FlZahlungslauf] 
(
	[ymDatumZahlungslauf] ASC,
	[FlTypZahlungslaufID] ASC
) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FlZahlungslauf_FlTypZahlungslaufID] ON [dbo].[FlZahlungslauf] 
(
	[FlTypZahlungslaufID] ASC
) ON [PRIMARY]
GO
/*
Diese wird nicht mehr gebraucht, der FK ist uns egal
ALTER TABLE [dbo].[OLD_30_FlZahlungslauf]  WITH CHECK ADD  CONSTRAINT [FK_FlZahlungslauf_FlTypZahlungslauf] FOREIGN KEY([FlTypZahlungslaufID])
REFERENCES [OLD_30_FlTypZahlungslauf] ([FlTypZahlungslaufID])
GO

ALTER TABLE [dbo].[FlZahlungslauf] CHECK CONSTRAINT [FK_FlZahlungslauf_FlTypZahlungslauf]
GO
*/