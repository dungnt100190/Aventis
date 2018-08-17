CREATE TABLE [dbo].[OLD_30_AiZahlung](
	[AiZahlungID] [int] IDENTITY(1,1) NOT NULL,
	[AiInkassofallID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Bemerkung] [varchar](1024) NULL,
	[DateZahlungseingang] [datetime] NOT NULL,
	[DateZahlungsverarbeitung] [datetime] NULL,
	[DateZahlungsverbuchung] [datetime] NULL,
	[AiZahlungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiZahlung] PRIMARY KEY NONCLUSTERED 
(
	[AiZahlungID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiZahlung] ON [dbo].[OLD_30_AiZahlung] 
(
	[AiInkassofallID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiZahlung]  WITH CHECK ADD  CONSTRAINT [FK_AiZahlung_AiInkassofall] FOREIGN KEY([AiInkassofallID])
REFERENCES [OLD_30_AiInkassoFall] ([AiInkassoFallID])
GO

ALTER TABLE [dbo].[OLD_30_AiZahlung] CHECK CONSTRAINT [FK_AiZahlung_AiInkassofall]
GO