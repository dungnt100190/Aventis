CREATE TABLE [dbo].[OLD_30_AiInkassoFall](
	[AiInkassoFallID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[AiBezugKinderzulagenCode] [int] NOT NULL CONSTRAINT [DF_AiInkassoFall_AiBezugKinderzulagenCode]  DEFAULT (1),
	[AiInkassofallStatusCode] [int] NOT NULL CONSTRAINT [DF_AiInkassoFall_AiInkassofallStatusCode]  DEFAULT (1),
	[AiInkassoTypID] [int] NOT NULL CONSTRAINT [DF_AiInkassoFall_AiInkassoTypID]  DEFAULT (1),
	[AiInkassoBemuehungCode] [int] NOT NULL CONSTRAINT [DF_AiInkassoFall_AiInkassoBemuehungCode]  DEFAULT (1),
	[AiEroeffnungGrundCode] [int] NULL,
	[AiAbschlussGrundCode] [int] NULL,
	[FbZahlungswegID] [int] NULL,
	[ESR] [varchar](30) NULL,
	[VerjaehrungAm] [datetime] NULL,
	[Forderungstitel] [varchar](2048) NULL,
	[Bemerkung] [text] NULL,
	[DatumVon] [datetime] NOT NULL CONSTRAINT [DF_AiInkassoFall_DatumVon]  DEFAULT (getdate()),
	[DatumBis] [datetime] NULL,
	[InkassoFallName] [varchar](50) NOT NULL,
	[Mahnlauf] [bit] NOT NULL CONSTRAINT [DF_AiInkassoFall_Mahnlauf]  DEFAULT (1),
	[AiInkassofallUnterartCode] [int] NULL,
	[AiEinnahmenQuoteCode] [int] NULL,
	[AiBegrErreichungsGradCode] [int] NULL,
	[AiInkassoFallTS] [timestamp] NOT NULL,
	[_mig_FaLeistungIDNeu] [int] NULL,
 CONSTRAINT [PK_AiInkassoFall] PRIMARY KEY NONCLUSTERED 
(
	[AiInkassoFallID] ASC
) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_AiInkassoFall] ON [dbo].[OLD_30_AiInkassoFall] 
(
	[FaLeistungID] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_AiInkassoFall]  WITH CHECK ADD  CONSTRAINT [FK_AiInkassoFall_AiInkassoTyp] FOREIGN KEY([AiInkassoTypID])
REFERENCES [OLD_30_AiInkassoTyp] ([AiInkassoTypID])
GO

ALTER TABLE [dbo].[OLD_30_AiInkassoFall]  WITH CHECK ADD  CONSTRAINT [FK_AiInkassoFall_FlZahlungsweg] FOREIGN KEY([FbZahlungswegID])
REFERENCES [OLD_30_FlZahlungsweg] ([FlZahlungswegID])
GO