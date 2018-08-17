CREATE TABLE [dbo].[OLD_30_AiForderungTyp](
	[AiForderungTypID] [int] NOT NULL,
	[FlKostenartZEID] [int] NULL,
	[FlKostenartZAID] [int] NULL,
	[AiForderungTypGruppeCode] [int] NULL,
	[ForderungTypText] [varchar](100) NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_ForderungTypText]  DEFAULT ('-/-'),
	[IsGlobalView] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_GlobalView]  DEFAULT (0),
	[IsBevorschussung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_Bevorschussung]  DEFAULT (0),
	[IsVermittlung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_Vermittlung]  DEFAULT (0),
	[IsUnterstuetzung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_Unterstuetzung]  DEFAULT (0),
	[ShowIndexierung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_ShowIndexierung]  DEFAULT (0),
	[ShowVeraenderung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_ShowVeraenderung]  DEFAULT (0),
	[MaxBetrag] [money] NOT NULL CONSTRAINT [DF_tcoKissAiForderungTyp_MaxBetrag]  DEFAULT (0),
	[SortKey] [int] NOT NULL,
	[AiForderungTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiForderungTyp] PRIMARY KEY NONCLUSTERED 
(
	[AiForderungTypID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiForderungTyp] ON [dbo].[OLD_30_AiForderungTyp] 
(
	[SortKey] ASC
) ON [PRIMARY]
GO