CREATE TABLE [dbo].[OLD_30_AiZahlungVsForderung](
	[AiZahlungVsForderungID] [int] IDENTITY(1,1) NOT NULL,
	[AiForderungID] [int] NOT NULL,
	[AiZahlungID] [int] NOT NULL,
	[Teilbetrag] [money] NOT NULL,
	[Bemerkung] [varchar](200) NULL,
	[InBuchhaltung] [bit] NOT NULL CONSTRAINT [DF_AiZahlungVsForderung_InBuchhaltung]  DEFAULT (0),
	[AiZahlungVsForderungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiZahlungVsForderung] PRIMARY KEY NONCLUSTERED 
(
	[AiZahlungVsForderungID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE UNIQUE CLUSTERED INDEX [IX_AiZahlungVsForderung] ON [dbo].[OLD_30_AiZahlungVsForderung] 
(
	[AiForderungID] ASC,
	[AiZahlungID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiZahlungVsForderung]  WITH CHECK ADD  CONSTRAINT [FK_AiZahlungVsForderung_AiForderung] FOREIGN KEY([AiForderungID])
REFERENCES [OLD_30_AiForderung] ([AiForderungID])
GO

ALTER TABLE [dbo].[OLD_30_AiZahlungVsForderung]  WITH CHECK ADD  CONSTRAINT [FK_tdfKissAiZahlungVsForderung_tdfKissAiZahlung] FOREIGN KEY([AiZahlungID])
REFERENCES [OLD_30_AiZahlung] ([AiZahlungID])
GO

ALTER TABLE [dbo].[OLD_30_AiZahlungVsForderung] CHECK CONSTRAINT [FK_tdfKissAiZahlungVsForderung_tdfKissAiZahlung]
GO