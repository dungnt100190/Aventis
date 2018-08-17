CREATE TABLE [dbo].[OLD_30_AiForderung](
	[AiForderungID] [int] IDENTITY(1,1) NOT NULL,
	[AiInkassofallID] [int] NOT NULL,
	[AiGlaeubigerID] [int] NULL,
	[AiForderungTypID] [int] NOT NULL,
	[AiIndexTypCode] [int] NOT NULL CONSTRAINT [DF_AiForderung_AiIndexTypCode]  DEFAULT (1),
	[AiRueckerstattungTypCode] [int] NULL,
	[FlKostenstelleID] [int] NULL,
	[VerfuegtAm] [datetime] NOT NULL CONSTRAINT [DF_AiForderung_VerfuegtAm]  DEFAULT (getdate()),
	[EingestelltAm] [datetime] NULL,
	[DateIndexBasis] [datetime] NULL,
	[IndexAnpassungMonat] [int] NULL CONSTRAINT [DF_AiForderung_IndexAnpassungMonat]  DEFAULT (1),
	[RueckwirkendAufMonat] [int] NULL CONSTRAINT [DF_AiForderung_RueckwirkendAufMonat]  DEFAULT (2),
	[IndexDifferenz] [real] NULL,
	[IndexAnpassung] [real] NULL,
	[IndexAnpassungLastChange] [real] NOT NULL CONSTRAINT [DF_AiForderung_IndexAnpassungLastChange]  DEFAULT (0),
	[Bemerkung] [text] NULL,
	[DateNextChange] [datetime] NULL,
	[NextChangeBecauseOf] [varchar](2048) NULL,
	[BvAktiv] [bit] NOT NULL CONSTRAINT [DF_AiForderung_BvAktiv]  DEFAULT (0),
	[BvAktivBis] [datetime] NOT NULL,
	[AiForderungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiForderung] PRIMARY KEY NONCLUSTERED 
(
	[AiForderungID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiForderung] ON [dbo].[OLD_30_AiForderung] 
(
	[AiInkassofallID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiForderung]  WITH CHECK ADD  CONSTRAINT [FK_AiForderung_AiForderungTyp] FOREIGN KEY([AiForderungTypID])
REFERENCES [OLD_30_AiForderungTyp] ([AiForderungTypID])
GO

ALTER TABLE [dbo].[OLD_30_AiForderung]  WITH CHECK ADD  CONSTRAINT [FK_AiForderung_AiGlaeubiger] FOREIGN KEY([AiGlaeubigerID])
REFERENCES [OLD_30_AiGlaeubiger] ([AiGlaeubigerID])
GO

ALTER TABLE [dbo].[OLD_30_AiForderung]  WITH CHECK ADD  CONSTRAINT [FK_AiForderung_AiInkassofall] FOREIGN KEY([AiInkassofallID])
REFERENCES [OLD_30_AiInkassoFall] ([AiInkassoFallID])
GO

ALTER TABLE [dbo].[OLD_30_AiForderung] CHECK CONSTRAINT [FK_AiForderung_AiInkassofall]
GO