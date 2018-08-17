CREATE TABLE [dbo].[BgKostenart](
	[BgKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[ModulID] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[KontoNr] [varchar](10) NULL,
	[BgKostenartTypCode] [int] NULL,
	[Hauptvorgang] [int] NULL,
	[Teilvorgang] [int] NULL,
	[Weiterverrechenbar] [bit] NOT NULL,
	[Quoting] [bit] NOT NULL,
	[BgSplittingArtCode] [int] NULL,
	[Belegart] [varchar](4) NULL,
	[HauptvorgangAbtretung] [int] NULL,
	[TeilvorgangAbtretung] [int] NULL,
	[FaFachbereichCode] [int] NOT NULL,
	[BgKostenartTS] [timestamp] NOT NULL,
	[BaZahlungswegIDFix] [int] NULL,
 CONSTRAINT [PK_BgKostenart] PRIMARY KEY CLUSTERED 
(
	[BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_BgKostenart_KontoNr] ON [dbo].[BgKostenart] 
(
	[KontoNr] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_BgKostenart_ModulID] ON [dbo].[BgKostenart] 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BgKostenart]  WITH CHECK ADD  CONSTRAINT [FK_BgKostenart_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[BgKostenart] CHECK CONSTRAINT [FK_BgKostenart_XModul]
GO

ALTER TABLE [dbo].[BgKostenart] ADD  CONSTRAINT [DF_BgKostenart_Weiterverrechenbar]  DEFAULT ((1)) FOR [Weiterverrechenbar]
GO

ALTER TABLE [dbo].[BgKostenart] ADD  CONSTRAINT [DF_BgKostenart_Quoting]  DEFAULT ((0)) FOR [Quoting]
GO

ALTER TABLE [dbo].[BgKostenart] ADD  CONSTRAINT [DF_BgKostenart_FaFachbereichCode]  DEFAULT ((1)) FOR [FaFachbereichCode]
GO


