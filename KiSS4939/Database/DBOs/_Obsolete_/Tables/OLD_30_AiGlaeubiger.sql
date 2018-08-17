CREATE TABLE [dbo].[OLD_30_AiGlaeubiger](
	[AiGlaeubigerID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Ausbildung] [varchar](1024) NULL,
	[Bemerkung] [text] NULL,
	[ElterlicheGewalt] [varchar](128) NULL,
	[AiGlaeubigerTS] [timestamp] NOT NULL,
	[_mig_FaLeistungIDNeu] [int] NULL,
 CONSTRAINT [PK_AiGlaeubiger] PRIMARY KEY NONCLUSTERED 
(
	[AiGlaeubigerID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO