CREATE TABLE [dbo].[OLD_30_AiBetreibung](
	[AiBetreibungID] [int] IDENTITY(1,1) NOT NULL,
	[AiInkassofallID] [int] NOT NULL,
	[AiBetreibungStatusCode] [int] NOT NULL CONSTRAINT [DF_tdfKissAiBetreibung_IdAiBetreibungStatus]  DEFAULT (1),
	[AiVerlustscheinStatusCode] [int] NOT NULL CONSTRAINT [DF_tdfKissAiBetreibung_IdAiVerlustscheinStatus]  DEFAULT (1),
	[AiVerlustscheinTypCode] [int] NOT NULL CONSTRAINT [DF_tdfKissAiBetreibung_IdAiVerlustscheinTyp]  DEFAULT (1),
	[BetreibungAm] [datetime] NOT NULL,
	[BetreibungNummer] [varchar](20) NULL,
	[BetreibungAmt] [varchar](200) NULL,
	[BetreibungBetrag] [money] NULL,
	[BetreibungVon] [datetime] NULL,
	[BetreibungBis] [datetime] NULL,
	[BetreibungFortsetzungAm] [datetime] NULL,
	[BetreibungVerwertungAm] [datetime] NULL,
	[BetreibungRechtsoeffnungAm] [datetime] NULL,
	[Glaeubiger] [varchar](200) NULL,
	[VerlustscheinAm] [datetime] NOT NULL,
	[VerlustscheinNummer] [varchar](20) NULL,
	[VerlustscheinAmt] [varchar](200) NULL,
	[VerlustscheinBetrag] [money] NULL,
	[VerlustscheinZins] [money] NULL,
	[VerlustscheinKosten] [money] NULL,
	[VerlustscheinVerjaehrungAm] [datetime] NULL,
	[Bemerkung] [varchar](1024) NULL,
	[AiBetreibungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiBetreibung] PRIMARY KEY NONCLUSTERED 
(
	[AiBetreibungID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiBetreibung] ON [dbo].[OLD_30_AiBetreibung] 
(
	[AiInkassofallID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiBetreibung]  WITH CHECK ADD  CONSTRAINT [FK_AiBetreibung_AiInkassofall] FOREIGN KEY([AiInkassofallID])
REFERENCES [OLD_30_AiInkassoFall] ([AiInkassoFallID])
GO

ALTER TABLE [dbo].[OLD_30_AiBetreibung] CHECK CONSTRAINT [FK_AiBetreibung_AiInkassofall]
GO