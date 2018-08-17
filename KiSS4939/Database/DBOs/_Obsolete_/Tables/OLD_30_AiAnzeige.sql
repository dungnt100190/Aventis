CREATE TABLE [dbo].[OLD_30_AiAnzeige](
	[AiAnzeigeID] [int] IDENTITY(1,1) NOT NULL,
	[AiInkassofallID] [int] NOT NULL,
	[AiAnzeigeReasonCloseCode] [int] NULL,
	[AiAnzeigeTypCode] [int] NOT NULL,
	[DateOpen] [datetime] NOT NULL CONSTRAINT [DF_tdfKissAiAnzeige_DateOpen]  DEFAULT (getdate()),
	[DateClose] [datetime] NULL,
	[ReasonOpen] [varchar](64) NULL,
	[Bemerkung] [varchar](1024) NULL,
	[AiAnzeigeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_AiAnzeige] PRIMARY KEY NONCLUSTERED 
(
	[AiAnzeigeID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiAnzeige] ON [dbo].[OLD_30_AiAnzeige] 
(
	[AiInkassofallID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiAnzeige]  WITH CHECK ADD  CONSTRAINT [FK_AiAnzeige_AiInkassofall] FOREIGN KEY([AiInkassofallID])
REFERENCES [OLD_30_AiInkassoFall] ([AiInkassoFallID])
GO

ALTER TABLE [dbo].[OLD_30_AiAnzeige] CHECK CONSTRAINT [FK_AiAnzeige_AiInkassofall]
GO