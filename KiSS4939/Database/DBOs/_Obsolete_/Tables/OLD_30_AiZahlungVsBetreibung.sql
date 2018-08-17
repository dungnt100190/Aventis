CREATE TABLE [dbo].[OLD_30_AiZahlungVsBetreibung](
	[AiZahlungVsBetreibungID] [int] IDENTITY(1,1) NOT NULL,
	[AiZahlungID] [int] NOT NULL,
	[AiBetreibungID] [int] NOT NULL,
	[Teilbetrag] [money] NOT NULL CONSTRAINT [DF_tdfKissAiZahlungVsBetreibung_Teilbetrag]  DEFAULT (0),
	[Bemerkung] [varchar](200) NULL,
	[AiZahlungVsBetreibungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiZahlungVsBetreibung] PRIMARY KEY NONCLUSTERED 
(
	[AiZahlungVsBetreibungID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE UNIQUE CLUSTERED INDEX [IX_AiZahlungVsBetreibung] ON [dbo].[OLD_30_AiZahlungVsBetreibung] 
(
	[AiBetreibungID] ASC,
	[AiZahlungID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiZahlungVsBetreibung]  WITH CHECK ADD  CONSTRAINT [FK_tdfKissAiZahlungVsBetreibung_tdfKissAiBetreibung] FOREIGN KEY([AiBetreibungID])
REFERENCES [OLD_30_AiBetreibung] ([AiBetreibungID])
GO

ALTER TABLE [dbo].[OLD_30_AiZahlungVsBetreibung]  WITH CHECK ADD  CONSTRAINT [FK_tdfKissAiZahlungVsBetreibung_tdfKissAiZahlung] FOREIGN KEY([AiZahlungID])
REFERENCES [OLD_30_AiZahlung] ([AiZahlungID])
GO