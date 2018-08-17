CREATE TABLE [dbo].[OLD_30_KaQJExtern](
	[KaQJExternID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[EinsatzVon] [datetime] NULL,
	[EinsatzBis] [datetime] NULL,
	[EinsatzCode] [int] NULL,
	[BetriebID] [int] NULL,
	[StageDokID] [int] NULL,
	[EinladungDokID] [int] NULL,
	[Berufswunsch] [varchar](200) NULL,
	[SichtbarSDFlag] [bit] NOT NULL DEFAULT (0),
	[KaQJExternTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJExtern] PRIMARY KEY CLUSTERED 
(
	[KaQJExternID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO