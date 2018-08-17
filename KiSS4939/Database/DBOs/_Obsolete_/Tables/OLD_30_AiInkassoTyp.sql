CREATE TABLE [dbo].[OLD_30_AiInkassoTyp](
	[AiInkassoTypID] [int] NOT NULL,
	[InkassoTypText] [varchar](50) NULL,
	[IsAliment] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsAliment]  DEFAULT (0),
	[IsElternbeitrag] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsElternbeitrag]  DEFAULT (0),
	[IsRueckerstattung] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsRueckerstattung]  DEFAULT (0),
	[IsVerwandtenbeitrag] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsVerwandtenbeitrag]  DEFAULT (0),
	[IsTagesheim] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsTagesheim]  DEFAULT (0),
	[IsNachlass] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_IsNachlass]  DEFAULT (0),
	[ShowGlaeubiger] [bit] NOT NULL CONSTRAINT [DF_tcoKissAiInkassoTyp_ShowPeople]  DEFAULT (1),
	[SortKey] [int] NOT NULL,
	[AiInkassoTypTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiInkassoTyp] PRIMARY KEY NONCLUSTERED 
(
	[AiInkassoTypID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiInkassoTyp] ON [dbo].[OLD_30_AiInkassoTyp] 
(
	[SortKey] ASC
) ON [PRIMARY]
GO